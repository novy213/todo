<?php

$params = require __DIR__ . '/params.php';
$db = require __DIR__ . '/db.php';

$config = [
    'id' => 'basic',
    'basePath' => dirname(__DIR__),
    'bootstrap' => ['log'],
    'aliases' => [
        '@bower' => '@vendor/bower-asset',
        '@npm'   => '@vendor/npm-asset',
    ],
    'components' => [
        'request' => [
            // !!! insert a secret key in the following (if it is empty) - this is required by cookie validation
            'cookieValidationKey' => 'todo',
        ],
        'cache' => [
            'class' => 'yii\caching\FileCache',
        ],
        'user' => [
            'identityClass' => 'app\models\User',
            'enableAutoLogin' => true,
        ],
        'errorHandler' => [
            'errorAction' => 'site/error',
        ],
        'mailer' => [
            'class' => \yii\symfonymailer\Mailer::class,
            'viewPath' => '@app/mail',
            // send all mails to a file by default.
            'useFileTransport' => true,
        ],
        'log' => [
            'traceLevel' => YII_DEBUG ? 3 : 0,
            'targets' => [
                [
                    'class' => 'yii\log\FileTarget',
                    'levels' => ['error', 'warning'],
                ],
            ],
        ],
        'db' => $db,
        'urlManager' => [
            'enablePrettyUrl' => true,
            'showScriptName' => false,
            'enableStrictParsing' => false,
            'rules' => [                        
                [
                    'pattern' => '/api/todo',
                    'route' => '/auth/login',
                    'verb' => 'POST',
                ],         
                [
                    'pattern' => '/api/todo',
                    'route' => '/auth/logout',
                    'verb' => 'DELETE',
                ],             
                [
                    'pattern' => '/api/todo/<project_id:\d+>',
                    'route' => '/site/gettasks',
                    'verb' => 'GET',
                ],                
                [
                    'pattern' => '/api/todo',
                    'route' => '/site/getprojects',
                    'verb' => 'GET',
                ],
                [
                    'pattern' => '/api/todo/register',
                    'route' => '/site/register',
                    'verb' => 'POST',
                ],
                [
                    'pattern' => '/api/todo/createproject',
                    'route' => '/site/createproject',
                    'verb' => 'POST',
                ],
                [
                    'pattern' => '/api/todo/<project_id:\d+>',
                    'route' => '/site/deleteproject',
                    'verb' => 'DELETE',
                ],  
                [
                    'pattern' => '/api/todo/<project_id:\d+>',
                    'route' => '/site/renameproject',
                    'verb' => 'PUT',
                ],    
                [
                    'pattern' => '/api/todo/<project_id:\d+>',
                    'route' => '/site/addtask',
                    'verb' => 'POST',
                ],           
                [
                    'pattern' => '/api/todo/project/<task_id:\d+>',
                    'route' => '/site/deletetask',
                    'verb' => 'DELETE',
                ],
                [
                    'pattern' => '/api/todo/project/<task_id:\d+>',
                    'route' => '/site/edittask',
                    'verb' => 'PUT',
                ],    
                [
                    'pattern' => '/api/todo/project/<task_id:\d+>',
                    'route' => '/site/marktask',
                    'verb' => 'POST',
                ],    
            ],    
        ],
        /*
        'urlManager' => [
            'enablePrettyUrl' => true,
            'showScriptName' => false,
            'rules' => [
            ],
        ],
        */
    ],
    'params' => $params,
];

if (YII_ENV_DEV) {
    // configuration adjustments for 'dev' environment
    $config['bootstrap'][] = 'debug';
    $config['modules']['debug'] = [
        'class' => 'yii\debug\Module',
        // uncomment the following to add your IP if you are not connecting from localhost.
        'allowedIPs' => ['127.0.0.1', '::1'],
    ];

    $config['bootstrap'][] = 'gii';
    $config['modules']['gii'] = [
        'class' => 'yii\gii\Module',
        'allowedIPs' => ['127.0.0.1', '::1', '192.168.0.*', '192.168.178.20' ,'172.23.0.1'] 
    ];
}

return $config;
