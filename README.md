# Specification
Todo - an application that allows us to create projects and add tasks to them.<br>
The application consists of 2 modules (server part and user part).<br>
The server part is made in the php Yii2 framework and the user part in the WPF framework, application uses rest Api.<br>
## Data range:
User: each user will have the following fields:<br>
- id
- login
- password
- name
- last name

Project: each project will consist of the following data:
- id
- project name
- user_id

Task: each task will have:
- id
- task description
- project_id

## Functions:
1. Login/Registration
2. Creating projects
3. Deleting projects
4. Changing the name of the project
5. Adding tasks to projects
6. Deleting tasks from projects
7. Changing the content of tasks in the project
8. Marking the task as done

## Database specification
The database contains 3 tables properly connected with each other.
### Users table:
- id - unique user ID
- login - user login
- password - user's encrypted password
- name - user's name
- last name - user's last name
### Projects table:
- id - unique id of the project
- user_id - field corresponding to the id field in the users table, connected by the relation (1..n)
- name - project name
### Task table:
- id - unique task id
- project_id - field corresponding to the id field in the table projects linked by a relation (1..n)
- description - task description
- done - a boolean field indicating whether a given task has been completed

# Installation
