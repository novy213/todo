# Specification
Todo - an application that allows us to create projects and add tasks to them.<br>
The application consists of 2 modules (server part and user part).<br>
The server part is made in the php Yii2 framework and the user part in the WPF framework.<br>
### Functions:
1. Login/Registration
2. Creating projects
3. Deleting projects
4. Changing the name of the project
5. Adding tasks to projects
6. Deleting tasks from projects
7. Changing the content of tasks in the project
8. Marking the task as done
# Api url
```
http://api.todo/v1
```
# 1.1 Create new project
```
PUT http://api.todo/v1
```
### Params:
```
(null)
```
### Body:
```
{
  "name":"project name",
}
```
### Response: 
```
{
  "error":false,
  "message": null
}
```
# 1.2 Delete project
```
DELETE http://api.todo/v1/{project-id}
```
### Params:
```
project-id - unique project id
```
### Body:
```
(null)
```
### Response: 
```
{
  "error":false,
  "message": null
}
```
# 1.3 Rename project
```
PUT http://api.todo/v1/{project-id}
```
### Params:
```
project-id - unique project id
```
### Body:
```
{
  "name": "new name",
}
```
### Response: 
```
{
  "error":false,
  "message": null
}
```
# 2.1 Add task to project
```
PUT http://api.todo/v1/{project-id}
```
### Params:
```
project-id - unique id of project
```
### Body:
```
{
  "text":"sample text",
}
```
### Response: 
```
{
  "error":false,
  "message": null
}
```
# 2.2 Remove task to project
```
DELETE http://api.todo/v1/{project-id}/{taskId}
```
### Params:
```
project-id - unique id of project
taskId - unique id of task
```
### Body:
```
(null)
```
### Response: 
```
{
  "error":false,
  "message": null
}
```
# Editing task
```
PUT http://api.todo/v1/{project-id}/{taskId}
```
### Params:
```
project-id - unique id of project
taskId - unique id of task
```
### Body:
```
{
  "text":"new text",
}
```
# Marked task as done
```
PUT http://api.todo/v1/{project-id}/{taskId}
```
### Params:
```
project-id - unique id of project
taskId - unique id of task
```
### Body:
```
{
  (null)
}
```
### Response: 
```
{
  "error":false,
  "message": null
}
```
# 3.1 Get projects list
```
GET http://api.todo/v1
```
### Params:
```
(null)
```
### Body:
```
(null)
```
### Response: 
```
{
  "error":false,
  "message": null,
  "projects": [
    {
      "id": 1,
      "name": "project1"
    },
    {
      "id": 2,
      "name": "project2"
    }
  ]
}
```
# 3.2 Get tasks list
```
GET http://api.todo/v1/{project-id}
```
### Params:
```
project-id - unique project id
```
### Body:
```
(null)
```
### Response: 
```
{
  "error":false,
  "message": null,
  "tasks": [
    {
      "id": 1,
      "text": "task1"
    },
    {
      "id": 2,
      "name": "task2"
    }
  ]
}
```
