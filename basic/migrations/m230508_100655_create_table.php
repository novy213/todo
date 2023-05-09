<?php

use yii\db\Migration;

/**
 * Handles the creation of table `users`.
 * Handles the creation of table 'projects'.
 * Handles the creation of table 'tasks'.
 */
class m230508_100655_create_table extends Migration
{
    /**
     * {@inheritdoc}
     */
    public function safeUp()
    {
        $this->createTable('user', [
            'id' => $this->primaryKey()->notNull()->unique(),
            'login' => $this->string()->notNull(),
            'password' => $this->string()->notNull(),
            'name' => $this->string(),
            'last_name' => $this->string()
        ]);        
        $this -> alterColumn('user','id', $this->integer().' AUTO_INCREMENT');
        $this->createTable('project', [
            'id' => $this->primaryKey()->notNull()->unique(),
            'project_name' => $this->string()->notNull(),
            'user_id' => $this->integer()->notNull()
        ]);
        $this -> alterColumn('project','id', $this->integer().' AUTO_INCREMENT');
        $this->addForeignKey(
            'fk-user_project',
            'project',
            'user_id',
            'user',
            'id',
            'CASCADE'
        );
        $this->createTable('task', [
            'id' => $this->primaryKey()->notNull()->unique(),
            'description' => $this->string()->notNull(),
            'done' => $this->boolean()->notNull()->defaultValue(false),
            'project_id' => $this->integer()->notNull()
        ]);    
        $this -> alterColumn('task','id', $this->integer().' AUTO_INCREMENT');
        $this->addForeignKey(
            'fk-project_task',
            'task',
            'project_id',
            'project',
            'id',
            'CASCADE'
        );    
    }

    /**
     * {@inheritdoc}
     */
    public function safeDown()
    {
        $this->dropTable('users');
        $this->dropTable('projects');
        $this->dropTable('tasks');
    }
}
