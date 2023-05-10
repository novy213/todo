using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using todo.Models;
using todo.Properties;
using unirest_net.http;
using unirest_net.request;

namespace todo
{
    public class Api
    {
        private const string HEADER_AUTHORIZATION = "Authorization";
        private const string API_ENDPOINT_LOGIN = "/";
        private const string API_ENDPOINT_LOGOUT = "/";
        private const string API_ENDPOINT_GET_TASKS = "/";
        private const string API_ENDPOINT_GET_PROJECTS = "/";
        private const string API_ENDPOINT_ADD_TASK = "/";
        private const string API_ENDPOINT_EDIT_TASK = "/project/";
        private const string API_ENDPOINT_MARK_TASK = "/project/";
        private const string API_ENDPOINT_DELETE_TASK = "/project/";
        private const string API_ENDPOINT_CREATE_PROJECT = "/createproject";
        private const string API_ENDPOINT_DELETE_PROJECT = "/";
        private const string API_ENDPOINT_RENAME_PROJECT = "/";
        private const string API_ENDPOINT_REGISTER = "/register";

        private const int HTTP_STATUS_OK = 200;
        private const int HTTP_STATUS_UNAUTHORIZED = 401;

        private static String Message;
        public static async Task<APIResponse> RegisterAsync(string Login, string Password, string Name, string Last_name)
        {
            APIResponse response;
            RegisterRequest request = new RegisterRequest
            {
                Login = Login,
                Password = Password,
                Name = Name,
                Last_name = Last_name
            };
            HttpRequest req = Unirest.post(Settings.Default.url + API_ENDPOINT_REGISTER).body<RegisterRequest>(request);
            try
            {
                HttpResponse<String> rawResponse = await MakeRequestAsync(req);
                if (rawResponse == null)
                {
                    response = new APIResponse
                    {
                        Error = true,
                        Message = Message
                    };
                }
                else
                {
                    response = JsonConvert.DeserializeObject<APIResponse>(rawResponse.Body);
                }

            }
            catch (Exception)
            {
                response = new APIResponse
                {
                    Error = true,
                    Message = "Unable to deserialize response from remote server"
                };
            }
            return response;
        }
        public static async Task<APIResponse> RenameProjectAsync(int Id, string Project_name)
        {
            APIResponse response;
            RenameProjectRequest request = new RenameProjectRequest
            {
                Project_name = Project_name
            };
            HttpRequest req = Unirest.put(Settings.Default.url + API_ENDPOINT_RENAME_PROJECT + Id).body<RenameProjectRequest>(request);
            try
            {
                HttpResponse<String> rawResponse = await MakeRequestAsync(req);
                if (rawResponse == null)
                {
                    response = new APIResponse
                    {
                        Error = true,
                        Message = Message
                    };
                }
                else
                {
                    response = JsonConvert.DeserializeObject<APIResponse>(rawResponse.Body);
                }

            }
            catch (Exception)
            {
                response = new APIResponse
                {
                    Error = true,
                    Message = "Unable to deserialize response from remote server"
                };
            }
            return response;
        }
        public static async Task<APIResponse> DeleteProjectAsync(int Id)
        {
            APIResponse response;
            HttpRequest req = Unirest.delete(Settings.Default.url + API_ENDPOINT_DELETE_PROJECT + Id);
            try
            {
                HttpResponse<String> rawResponse = await MakeRequestAsync(req);
                if (rawResponse == null)
                {
                    response = new APIResponse
                    {
                        Error = true,
                        Message = Message
                    };
                }
                else
                {
                    response = JsonConvert.DeserializeObject<APIResponse>(rawResponse.Body);
                }

            }
            catch (Exception)
            {
                response = new APIResponse
                {
                    Error = true,
                    Message = "Unable to deserialize response from remote server"
                };
            }
            return response;
        }
        public static async Task<APIResponse> CreateProjectAsync(int User_id, string Project_name)
        {
            APIResponse response;
            CreateProjectRequest request = new CreateProjectRequest
            {
                User_id = User_id,
                Project_name = Project_name
            };
            HttpRequest req = Unirest.post(Settings.Default.url + API_ENDPOINT_CREATE_PROJECT).body<CreateProjectRequest>(request);
            try
            {
                HttpResponse<String> rawResponse = await MakeRequestAsync(req);
                if (rawResponse == null)
                {
                    response = new APIResponse
                    {
                        Error = true,
                        Message = Message
                    };
                }
                else
                {
                    response = JsonConvert.DeserializeObject<APIResponse>(rawResponse.Body);
                }

            }
            catch (Exception)
            {
                response = new APIResponse
                {
                    Error = true,
                    Message = "Unable to deserialize response from remote server"
                };
            }
            return response;
        }
        public static async Task<APIResponse> DeleteTaskAsync(int Id)
        {
            APIResponse response;
            HttpRequest req = Unirest.delete(Settings.Default.url + API_ENDPOINT_DELETE_TASK + Id);
            try
            {
                HttpResponse<String> rawResponse = await MakeRequestAsync(req);
                if (rawResponse == null)
                {
                    response = new APIResponse
                    {
                        Error = true,
                        Message = Message
                    };
                }
                else
                {
                    response = JsonConvert.DeserializeObject<APIResponse>(rawResponse.Body);
                }

            }
            catch (Exception)
            {
                response = new APIResponse
                {
                    Error = true,
                    Message = "Unable to deserialize response from remote server"
                };
            }
            return response;
        }
        public static async Task<APIResponse> MarkTaskAsync(int Id, int Done)
        {
            APIResponse response;
            MarkTaskRequest request = new MarkTaskRequest
            {
                Done = Done
            };
            HttpRequest req = Unirest.post(Settings.Default.url + API_ENDPOINT_MARK_TASK + Id).body<MarkTaskRequest>(request);
            try
            {
                HttpResponse<String> rawResponse = await MakeRequestAsync(req);
                if (rawResponse == null)
                {
                    response = new APIResponse
                    {
                        Error = true,
                        Message = Message
                    };
                }
                else
                {
                    response = JsonConvert.DeserializeObject<APIResponse>(rawResponse.Body);
                }

            }
            catch (Exception)
            {
                response = new APIResponse
                {
                    Error = true,
                    Message = "Unable to deserialize response from remote server"
                };
            }
            return response;
        }
        public static async Task<APIResponse> EditTaskAsync(string Description, int Id)
        {
            APIResponse response;
            EditTaskRequest request = new EditTaskRequest
            {
                Description = Description
            };
            HttpRequest req = Unirest.put(Settings.Default.url + API_ENDPOINT_EDIT_TASK + Id).body<EditTaskRequest>(request);
            try
            {
                HttpResponse<String> rawResponse = await MakeRequestAsync(req);
                if (rawResponse == null)
                {
                    response = new APIResponse
                    {
                        Error = true,
                        Message = Message
                    };
                }
                else
                {
                    response = JsonConvert.DeserializeObject<APIResponse>(rawResponse.Body);
                }

            }
            catch (Exception)
            {
                response = new APIResponse
                {
                    Error = true,
                    Message = "Unable to deserialize response from remote server"
                };
            }
            return response;
        }
        public static async Task<APIResponse> AddTaskAsync(string Description, int Project_id)
        {
            APIResponse response;
            AddTaskRequest request = new AddTaskRequest
            {
                Description = Description
            };
            HttpRequest req = Unirest.post(Settings.Default.url + API_ENDPOINT_ADD_TASK + Project_id).body<AddTaskRequest>(request);
            try
            {
                HttpResponse<String> rawResponse = await MakeRequestAsync(req);
                if (rawResponse == null)
                {
                    response = new GetTasksListResponse
                    {
                        Error = true,
                        Message = Message
                    };
                }
                else
                {
                    response = JsonConvert.DeserializeObject<APIResponse>(rawResponse.Body);
                }

            }
            catch (Exception)
            {
                response = new APIResponse
                {
                    Error = true,
                    Message = "Unable to deserialize response from remote server"
                };
            }
            return response;
        }
        public static async Task<GetTasksListResponse> GetTasksListAsync(int Project_id)
        {
            GetTasksListResponse response;
            HttpRequest req = Unirest.get(Settings.Default.url + API_ENDPOINT_GET_TASKS + Project_id);
            try
            {
                HttpResponse<String> rawResponse = await MakeRequestAsync(req);
                if (rawResponse == null)
                {
                    response = new GetTasksListResponse
                    {
                        Error = true,
                        Message = Message
                    };
                }
                else
                {
                    response = JsonConvert.DeserializeObject<GetTasksListResponse>(rawResponse.Body);
                }

            }
            catch (Exception)
            {
                response = new GetTasksListResponse
                {
                    Error = true,
                    Message = "Unable to deserialize response from remote server"
                };
            }
            return response;
        }
        public static async Task<GetProjectListResponse> GetProjectsListAsync()
        {
            GetProjectListResponse response;
            HttpRequest req = Unirest.get(Settings.Default.url + API_ENDPOINT_GET_PROJECTS);
            try
            {
                HttpResponse<String> rawResponse = await MakeRequestAsync(req);
                if (rawResponse == null)
                {
                    response = new GetProjectListResponse
                    {
                        Error = true,
                        Message = Message
                    };
                }
                else
                {
                    response = JsonConvert.DeserializeObject<GetProjectListResponse>(rawResponse.Body);
                }

            }
            catch (Exception)
            {
                response = new GetProjectListResponse
                {
                    Error = true,
                    Message = "Unable to deserialize response from remote server"
                };
            }
            return response;
        }
        public static async Task<LoginResponse> LoginAsync(string Login, string Password)
        {
            LoginResponse response;
            LoginRequest loginInfo = new LoginRequest
            {
                Login = Login,
                Password = Password
            };
            HttpRequest req = Unirest.post(Settings.Default.url + API_ENDPOINT_LOGIN).body<LoginRequest>(loginInfo);
            try
            {
                HttpResponse<String> rawResponse = await MakeRequestAsync(req);
                if (rawResponse == null)
                {
                    response = new LoginResponse
                    {
                        Error = true,
                        Message = Message
                    };
                }
                else
                {
                    response = JsonConvert.DeserializeObject<LoginResponse>(rawResponse.Body);
                    if (rawResponse.Code == HTTP_STATUS_OK)
                    {
                        Settings.Default.accessToken = response.Token;
                        Settings.Default.user_id = response.User_id;
                        Settings.Default.Save();
                    }
                }

            }
            catch (Exception)
            {
                response = new LoginResponse
                {
                    Error = true,
                    Message = "Unable to deserialize response from remote server"
                };
            }
            return response;
        }
        public static async Task<APIResponse> LogoutAsync()
        {
            APIResponse response;
            HttpRequest req = Unirest.delete(Settings.Default.url + API_ENDPOINT_LOGOUT);
            try
            {
                HttpResponse<String> rawResponse = await MakeRequestAsync(req);
                if (rawResponse == null)
                {
                    response = new LoginResponse
                    {
                        Error = true,
                        Message = Message
                    };
                }
                else
                {
                    response = JsonConvert.DeserializeObject<APIResponse>(rawResponse.Body);
                    if (rawResponse.Code == HTTP_STATUS_OK)
                    {
                        Settings.Default.accessToken = "";
                        Settings.Default.user_id = 0;
                        Settings.Default.Save();
                    }
                }

            }
            catch (Exception)
            {
                response = new LoginResponse
                {
                    Error = true,
                    Message = "Unable to deserialize response from remote server"
                };
            }
            return response;
        }
        public static string GetAuthHeaders()
        {
            return HEADER_AUTHORIZATION + ": " + "Bearer " + Settings.Default.accessToken;
        }
        private static async Task<HttpResponse<string>> MakeRequestAsync(HttpRequest req)
        {
            Task<HttpResponse<String>> resultTask;
            HttpResponse<String> result;
            if (Settings.Default.accessToken != "")
            {
                req.header(HEADER_AUTHORIZATION, "Bearer " + Settings.Default.accessToken);
            }
            Message = "";
            resultTask = req.asStringAsync();
            try
            {
                result = await resultTask;
                if (result.Code == HTTP_STATUS_UNAUTHORIZED)
                {
                    Settings.Default.accessToken = "";
                    result.Body = "{\"error\":false, \"message\":\"\"}";
                    Settings.Default.Save();
                }
            }
            catch (AggregateException ae)
            {
                Message = ae.InnerException.Message;
                result = null;
            }
            catch (Exception e)
            {
                Message = e.Message;
                result = null;
            }
            return result;
        }
    }
}
