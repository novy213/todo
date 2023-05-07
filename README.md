# Info
null<br>
# 1.1 Api url
```
http://api.todo/v1
```
# 1.2 Add task to project
```
PUT http://api.todo/v1/project-id
```
###Params:
```
project-id - unique id of project
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
# 1.3 Remove task to project
```
DELETE http://api.todo/v1/{project-id}/{taskId}
```
###Params:
```
project-id - unique id of project
taskId - unique id of task
```
###Body:
```
(null)
```
###Response: 
```
{
  "error":false,
  "message": null
}
