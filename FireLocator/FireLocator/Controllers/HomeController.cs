using FireLocator.Models;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace FireLocator.Controllers
{
    public class HomeController : Controller
    {
        IFirebaseConfig config = new FirebaseConfig
        {
             AuthSecret = "UHBnEnbJTOskotikV96PeuBvG19SZmXEcqXefYc9",
             BasePath = "https://arduinoprojectfinal-default-rtdb.firebaseio.com/"
        };
        IFirebaseClient client;

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }



        [HttpPost]
        public ActionResult Index(User_Info userInfo)
        {
          
            try
            {
                AddUserInfo(userInfo);
                ModelState.AddModelError(string.Empty, "Added Successfully");
            }
            catch(Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View();
        }

        private void AddUserInfo(User_Info userInfo)
        {
            userInfo.Heat_Level_Last = "0";
            client = new FireSharp.FirebaseClient(config);
            var data = userInfo;
            //PushResponse response = client.Push("User_Info/", data);
            //data.Item = response.Result.name;
            SetResponse setResponse = client.Set("User_Info/" + data.Item, data);

        }



        [HttpGet]
        public ActionResult Tracking()
        {
            client = new FireSharp.FirebaseClient(config);
            FirebaseResponse response = client.Get("User_Info");
            dynamic data = JsonConvert.DeserializeObject<dynamic>(response.Body);
            var list = new List<User_Info>();
            if (data != null)
            {
                foreach (var item in data)
                {
                    list.Add(JsonConvert.DeserializeObject<User_Info>(((JProperty)item).Value.ToString()));
                }
            }
            return View(list);
        }

        [HttpGet]
        public ActionResult Alert()
        {
            client = new FireSharp.FirebaseClient(config);
            FirebaseResponse response = client.Get("User_Info");
            dynamic data = JsonConvert.DeserializeObject<dynamic>(response.Body);
            var list = new List<User_Info>();
            if (data != null)
            {
                foreach (var item in data)
                {
                    list.Add(JsonConvert.DeserializeObject<User_Info>(((JProperty)item).Value.ToString()));
                }
            }
            return View(list);
        }

        [HttpGet]
        public ActionResult FireVictim()
        {
            client = new FireSharp.FirebaseClient(config);
            FirebaseResponse response = client.Get("Victim");
            dynamic data = JsonConvert.DeserializeObject<dynamic>(response.Body);
            var list = new List<Victim_Info>();
            if (data != null)
            {
                foreach (var item in data)
                {
                    list.Add(JsonConvert.DeserializeObject<Victim_Info>(((JProperty)item).Value.ToString()));
                }
            }
            return View(list);
        }

        [HttpGet]
        public ActionResult HeavyList()
        {
            client = new FireSharp.FirebaseClient(config);
            FirebaseResponse response = client.Get("Victim");
            dynamic data = JsonConvert.DeserializeObject<dynamic>(response.Body);
            var list = new List<Victim_Info>();
            if (data != null)
            {
                foreach (var item in data)
                {
                    Victim_Info v = JsonConvert.DeserializeObject<Victim_Info>(((JProperty)item).Value.ToString());
                    if (v.Status.Equals("Heavy"))
                    {
                        list.Add(v);
                    }
                }
            }
            return View(list);
        }

        [HttpGet]
        public ActionResult LightList()
        {
            client = new FireSharp.FirebaseClient(config);
            FirebaseResponse response = client.Get("Victim");
            dynamic data = JsonConvert.DeserializeObject<dynamic>(response.Body);
            var list = new List<Victim_Info>();
            if (data != null)
            {
                foreach (var item in data)
                {
                    Victim_Info v = JsonConvert.DeserializeObject<Victim_Info>(((JProperty)item).Value.ToString());
                    if (v.Status.Equals("Light"))
                    {
                        list.Add(v);
                    }
                }
            }
            return View(list);
        }

        [HttpGet]
        public ActionResult Details(string id)
        {
            client = new FireSharp.FirebaseClient(config);
            FirebaseResponse response = client.Get("User_Info/" + id);
            dynamic data = JsonConvert.DeserializeObject<User_Info>(response.Body.ToString());
            return View(data);
        }

        [HttpGet]
        public ActionResult LocateDetails(string id)
        {
            client = new FireSharp.FirebaseClient(config);
            FirebaseResponse response = client.Get("User_Info/" + id);
            dynamic data = JsonConvert.DeserializeObject<User_Info>(response.Body.ToString());
            return View(data);
        }

        [HttpGet]
        public ActionResult Details1(string id)
        {
            client = new FireSharp.FirebaseClient(config);
            FirebaseResponse response = client.Get("User_Info/" + id);
            dynamic data = JsonConvert.DeserializeObject<User_Info>(response.Body.ToString());
            return View(data);
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            if (id != null)
            {
                client = new FireSharp.FirebaseClient(config);
                FirebaseResponse response = client.Delete("User_Info/" + id);
            }
            return RedirectToAction("Tracking");
        }

        [HttpGet]
        public ActionResult DeleteVictim(string id)
        {
            if (id != null)
            {
                client = new FireSharp.FirebaseClient(config);
                FirebaseResponse response = client.Delete("Victim/" + id);
            }
            return RedirectToAction("FireVictim");
        }

        [HttpGet]
        public ActionResult DeleteHeavy(string id)
        {
            if (id != null)
            {
                client = new FireSharp.FirebaseClient(config);
                FirebaseResponse response = client.Delete("Victim/" + id);
            }
            return RedirectToAction("HeavyList");
        }

        [HttpGet]
        public ActionResult DeleteLight(string id)
        {
            if (id != null)
            {
                client = new FireSharp.FirebaseClient(config);
                FirebaseResponse response = client.Delete("Victim/" + id);
            }
            return RedirectToAction("LightList");
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            client = new FireSharp.FirebaseClient(config);
            FirebaseResponse response = client.Get("User_Info/" + id);
            User_Info data = JsonConvert.DeserializeObject<User_Info>(response.Body);
            return View(data);
        }

        [HttpGet]
        public ActionResult Edit1(string id)
        {
            client = new FireSharp.FirebaseClient(config);
            FirebaseResponse response = client.Get("User_Info/" + id);
            User_Info data = JsonConvert.DeserializeObject<User_Info>(response.Body);
            return View(data);
        }

        [HttpGet]
        public async System.Threading.Tasks.Task<ActionResult> Dashboard()
        {
            Main_Info m = new Main_Info();
            m.userInfo = new List<User_Info>();
            client = new FireSharp.FirebaseClient(config);
            FirebaseResponse response =await client.GetAsync("User_Info");
            dynamic data = JsonConvert.DeserializeObject<dynamic>(response.Body);
            if (data != null)
            {
                foreach (var item in data)
                {
                    User_Info userInfo = JsonConvert.DeserializeObject<User_Info>(((JProperty)item).Value.ToString());
                    m.userInfo.Add(userInfo);
                }
            }
            m.total_user = m.userInfo.Count;

            FirebaseResponse response1 = await client.GetAsync("Victim");
            dynamic victimInfo = JsonConvert.DeserializeObject<dynamic>(response1.Body);
            if (victimInfo != null)
            {
                foreach (var item1 in victimInfo)
                {
                    m.total_fire_victim += 1;
                    Victim_Info victim = JsonConvert.DeserializeObject<Victim_Info>(((JProperty)item1).Value.ToString());
                    if (victim.Status.Equals("Heavy"))
                    {
                        m.heavy += 1;
                    }
                    else if (victim.Status.Equals("Light"))
                    {
                        m.light += 1;
                    }
                    if (victim.City.Equals("Paranaque City"))
                    {
                        m.paranaque += 1;
                    }
                    else if (victim.City.Equals("Makati City"))
                    {
                        m.makati += 1;
                    }
                    else if (victim.City.Equals("Muntinlupa City"))
                    {
                        m.muntinlupa += 1;
                    }
                    else if (victim.City.Equals("Pasay City"))
                    {
                        m.pasay += 1;
                    }
                    else if (victim.City.Equals("Taguig City"))
                    {
                        m.taguig += 1;
                    }
                }
            }
            return View(m);
        }


        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> Dashboard(Victim_Info victimInfo)
        {
            try
            {
                client = new FireSharp.FirebaseClient(config);
                PushResponse response = client.Push("Victim/", victimInfo);
                victimInfo.ID_victim = response.Result.name;
                FirebaseResponse setResponse = await client.SetAsync("Victim/" + victimInfo.ID_victim, victimInfo);
                ModelState.AddModelError(string.Empty, "Added Victim Successfully");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return RedirectToAction("Dashboard");
        }



        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> Edit(User_Info user_info)
        {

            if (!(user_info.Item == null || user_info.Item == ""))
            {
                client = new FireSharp.FirebaseClient(config);
                FirebaseResponse setResponse = await client.UpdateAsync("User_Info/" + user_info.Item, user_info);
            }
            return RedirectToAction("Tracking");
        }

        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> Edit1(User_Info user_info)
        {

            if (!(user_info.Item == null || user_info.Item == ""))
            {
                client = new FireSharp.FirebaseClient(config);
                FirebaseResponse setResponse = await client.UpdateAsync("User_Info/" + user_info.Item, user_info);
            }
            return RedirectToAction("Dashboard");
        }



        public ActionResult About()
        {
            var name = new User_Info() { Fullname = "R-jay" };
            ViewBag.Message = "Your application description page.";

            return View(name);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        [HttpGet]
        public ActionResult VictimDetails(String id)
        {
            client = new FireSharp.FirebaseClient(config);
            FirebaseResponse response = client.Get("Victim/" + id);
            dynamic data = JsonConvert.DeserializeObject<Victim_Info>(response.Body.ToString());
            return View(data);
        }

        [HttpGet]
        public ActionResult HeavyDetails(String id)
        {
            client = new FireSharp.FirebaseClient(config);
            FirebaseResponse response = client.Get("Victim/" + id);
            dynamic data = JsonConvert.DeserializeObject<Victim_Info>(response.Body.ToString());
            return View(data);
        }

        [HttpGet]
        public ActionResult LightDetails(String id)
        {
            client = new FireSharp.FirebaseClient(config);
            FirebaseResponse response = client.Get("Victim/" + id);
            dynamic data = JsonConvert.DeserializeObject<Victim_Info>(response.Body.ToString());
            return View(data);
        }

        [HttpGet]
        public ActionResult VictimEdit(String id)
        {
            client = new FireSharp.FirebaseClient(config);
            FirebaseResponse response = client.Get("Victim/" + id);
            dynamic data = JsonConvert.DeserializeObject<Victim_Info>(response.Body.ToString());
            return View(data);
        }

        [HttpGet]
        public ActionResult HeavyEdit(String id)
        {
            client = new FireSharp.FirebaseClient(config);
            FirebaseResponse response = client.Get("Victim/" + id);
            dynamic data = JsonConvert.DeserializeObject<Victim_Info>(response.Body.ToString());
            return View(data);
        }

        [HttpGet]
        public ActionResult LightEdit(String id)
        {
            client = new FireSharp.FirebaseClient(config);
            FirebaseResponse response = client.Get("Victim/" + id);
            dynamic data = JsonConvert.DeserializeObject<Victim_Info>(response.Body.ToString());
            return View(data);
        }

        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> VictimEdit(Victim_Info victimInfo)
        {

            if (!(victimInfo.Item == null || victimInfo.Item == "" || victimInfo.ID_victim == null || victimInfo.ID_victim == ""))
            {
                client = new FireSharp.FirebaseClient(config);
                FirebaseResponse setResponse = await client.UpdateAsync("Victim/" + victimInfo.ID_victim, victimInfo);
            }
            return RedirectToAction("FireVictim");
        }

        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> HeavyEdit(Victim_Info victimInfo)
        {

            if (!(victimInfo.Item == null || victimInfo.Item == "" || victimInfo.ID_victim == null || victimInfo.ID_victim == ""))
            {
                client = new FireSharp.FirebaseClient(config);
                FirebaseResponse setResponse = await client.UpdateAsync("Victim/" + victimInfo.ID_victim, victimInfo);
            }
            return RedirectToAction("HeavyList");
        }

        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> LightEdit(Victim_Info victimInfo)
        {

            if (!(victimInfo.Item == null || victimInfo.Item == "" || victimInfo.ID_victim == null || victimInfo.ID_victim == ""))
            {
                client = new FireSharp.FirebaseClient(config);
                FirebaseResponse setResponse = await client.UpdateAsync("Victim/" + victimInfo.ID_victim, victimInfo);
            }
            return RedirectToAction("LightList");
        }
    }
}