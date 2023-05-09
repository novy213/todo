<?php

namespace app\controllers;

use Yii;

use app\models\User;

use app\models\ApiToken;

use app\models\Legal;

use app\models\Client;
use app\components\Controller;

class AuthController extends Controller
{
    /**
     * Log in action
     *
     * @return string
     */
    public function actionLogin()
    {
        $post = $this->getJsonInput();
        $username = isset($post->login) ? $post->login : NULL;
        $password = isset($post->password) ? $post->password : NULL;
        if (is_null($username) || is_null($password)) {
            Yii::$app->response->statusCode = 400;
            return ['error' => TRUE, 'message' => 'Both user name and password are required.'];
        }
        $user = User::findByUsername($username);
        if (is_null($user)) {
            Yii::$app->response->statusCode = 400;
            return ['error' => TRUE, 'message' => 'Incorrect user name or password.'];
        }
        if (!$user->validatePassword($password)) {            
            Yii::$app->response->statusCode = 400;
            return ['error' => TRUE, 'message' => 'Incorrect user name or password.'];
        }
        $token = $user->createApiToken();
        return [
            'error' => FALSE,
            'message' => NULL,
            'token' => $token,            
            'userId' => $user->id,
        ];
    }
    /**
     * Log out action
     *
     * @return string
     */

    public function actionLogout()
    {
        $user = Yii::$app->user->identity;
        $user->clearApiToken();
        return [
            'error' => FALSE,
            'message' => NULL,
        ];
    }    
}