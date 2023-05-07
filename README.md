# Info
null<br>
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
### Response: 
```
{
  "error":false,
  "message": null
}
```
