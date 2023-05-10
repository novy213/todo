<?php

namespace app\components;

use Yii;
use yii\filters\auth\HttpBearerAuth;

/**
 * Base Controller for api module
 */
class Controller extends \yii\web\Controller
{

    public function init() {
        parent::init();
        $this->enableCsrfValidation = false;
        Yii::$app->response->format = \yii\web\Response::FORMAT_JSON;
    }

    public function behaviors() {
        $behaviors =  parent::behaviors();
        $behaviors['userTokenAuth'] = [
            'class' => HttpBearerAuth::className(),
            'except' => ['login', 'register'],
        ];
        return $behaviors;
    }

    public function getJsonInput() {
        return json_decode(Yii::$app->request->rawBody);
    }

    public function runAction($id, $params = array())
    {
        try {
            return parent::runAction($id, $params);
        } catch (\yii\web\HttpException $e) {
            Yii::error($e);            
            Yii::$app->response->statusCode = $e->statusCode;
            return [
                'error' => true,
                'message' => $e->getMessage()
            ];
        } catch (\Exception $e) {
            Yii::error($e);
            print_r($e);
            Yii::$app->response->statusCode = 500;
            return [
                'error' => true,
                'message' => YII_DEBUG ? $e->getMessage() : 'Internal server error',
            ];
        }
    }
}