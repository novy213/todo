# Info
null<br>
# 1.1 Api url
```
http://api.todo/v1
```
# 1.2 Add task to project
```
PUT http://api.todo/v1/project-id

### Params:
(null)

### Body:
project-id - unique id of project

### Response: 
{
  "error":false,
  "message": null
}
```
# 1.3 Remove task to project
```
DELETE http://api.todo/v1/project-name/taskId
```
