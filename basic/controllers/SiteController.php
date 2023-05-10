<?php

namespace app\controllers;

use app\models\Task;
use Yii;
use yii\filters\AccessControl;
use app\components\Controller;
use yii\web\Response;
use yii\filters\VerbFilter;
use app\models\LoginForm;
use app\models\ContactForm;
use app\models\Project;
use app\models\User;

class SiteController extends Controller
{
    /**
     * {@inheritdoc}
     */
    public function actions()
    {
        return [
            'error' => [
                'class' => 'yii\web\ErrorAction',
            ],            
        ];
    }    
    /**
     * 
     */
    public function actionRegister(){

        $post = $this->getJsonInput();        
        $user = new User();
        //$user->attributes = $post;
        if (isset($post->login)) {
            $user->login = $post->login;
        }
        if (isset($post->password)) {
            $user->password = $post->password;
        }
        if (isset($post->name)) {
            $user->name = $post->name;
        }
        if (isset($post->last_name)) {
            $user->last_name = $post->last_name;
        }
        if ($user->validate()) {
            $user->save();
            return [
                'error' => FALSE,
                'message' => NULL,                
            ];
        } else {
            return [
                'error' => true,
                'message' => $user->getErrorSummary(false),
            ];
        }                
    }
    public function actionCreateproject(){
        $post = $this->getJsonInput();        
        $project = new Project();
        if (isset($post->project_name)) {
            $project->project_name = $post->project_name;
        }
        if (isset($post->user_id)) {
            $project->user_id = $post->user_id;
        }        
        if ($project->validate()) {
            $project->save();
            return [
                'error' => FALSE,
                'message' => NULL,                
            ];
        } else {
            return [
                'error' => true,
                'message' => $project->getErrorSummary(false),
            ];
        }  
    }
    public function actionGetprojects(){           
        $user = Yii::$app->user->identity;
        if ($user != null) {            
            return [
                'error' => FALSE,
                'message' => NULL,    
                'projects' => $user->projects          
            ];
        } else {
            return [
                'error' => true,
                'message' => 'Error',
            ];
        }  
    }
    public function actionRenameproject($project_id){
        $post = $this->getJsonInput();
        $project = Project::find()->andWhere(['id'=>$project_id])->one();
        if(!$project){
            return [
                'error' => true,
                'message' => 'Project not found',
            ];
        }        
        if (!is_null($post)) {
            $project->project_name = $post->project_name;
            $project->update();
            return [
                'error' => FALSE,
                'message' => NULL,                
            ];
        } else {
            return [
                'error' => true,
                'message' => $project->getErrorSummary(false),
            ];
        }  
    }
    public function actionDeleteproject($project_id){
        if(!$project_id){
            return [
                'error' => true,
                'message' => 'Project not found',
            ];
        } else {
            $project = Project::find()->andWhere(['id'=>$project_id])->one();
            Project::deleteAll(['id'=>$project->id]);
            return [
                'error' => FALSE,
                'message' => NULL,                
            ];
        }
    }
    public function actionAddtask($project_id){
        $post = $this->getJsonInput();        
        $task = new Task();
        if (isset($post->description)) {
            $task->description = $post->description;
        }
        if (isset($project_id)) {
            $task->project_id = $project_id;
        }        
        if ($task->validate()) {
            $task->save();
            return [
                'error' => FALSE,
                'message' => NULL,                
            ];
        } else {
            return [
                'error' => true,
                'message' => $task->getErrorSummary(false),
            ];
        }  
    }
    public function actionEdittask($task_id){
        $post = $this->getJsonInput();
        $project = Task::find()->andWhere(['id'=>$task_id])->one();
        if(!$project){
            return [
                'error' => true,
                'message' => 'Task not found',
            ];
        }
        if (!is_null($post)) {
            $project->description = $post->description;
            $project->update();
            return [
                'error' => FALSE,
                'message' => NULL,                
            ];
        } else {
            return [
                'error' => true,
                'message' => $project->getErrorSummary(false),
            ];
        }  
    }
    public function actionGettasks($project_id){        
        if (!isset($project_id)) {
            return [
                'error' => true,
                'message' => 'project id is required',
            ];
        }
        $task = Task::find()->andWhere(['project_id'=>$project_id])->all();
        if ($task != null) {            
            return [
                'error' => FALSE,
                'message' => NULL,    
                'tasks' => $task
            ];
        } else {
            return [
                'error' => true,
                'message' => 'There is not tasks in project',
            ];
        }  
    }
    public function actionDeletetask($task_id){
        $task = Task::find()->andWhere(['id'=>$task_id])->one();
        if(!$task){
            return [
                'error' => true,
                'message' => 'Task not found',
            ];
        } else {
            $task->delete();
            return [
                'error' => FALSE,
                'message' => NULL,                
            ];
        }
    }
    public function actionMarktask($task_id){
        $post = $this->getJsonInput();
        $task = Task::find()->andWhere(['id'=>$task_id])->one();
        if(!$task){
            return [
                'error' => true,
                'message' => 'Task not found',
            ];
        }
        if (!is_null($post)) {
            $task->done = $post->done;
            $task->update();
            return [
                'error' => FALSE,
                'message' => NULL,                
            ];
        } else {
            return [
                'error' => true,
                'message' => $task->getErrorSummary(false),
            ];
        }  
    }
}
