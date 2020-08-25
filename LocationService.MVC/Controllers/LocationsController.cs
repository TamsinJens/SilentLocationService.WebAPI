using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;
using LocationService.MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SilentLocationService.Lib.DTO;
using SilentLocationService.Lib.Models;
using SilentLocationService.WebAPI.ViewModels;

namespace LocationService.MVC.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LocationsController : Controller
    {
        string baseuri = "https://localhost:5001/api/locations";

        public IActionResult Index()
        {
            string locationUri = $"{baseuri}/simple";
            return View(GetApiResult<List<LocationSimple>>(locationUri));
        }

        public IActionResult Chat()
        {
            return View();
        }

        public IActionResult Detail(int id)
        {
            string LocationUri = $"{baseuri}/{id}";
            return View(new LocationDetailVM
            {
                LocationDetail = GetApiResult<LocationDetail>(LocationUri)
            });
        }

        public IActionResult Edit(int id)
        {
            string LocationUri = $"{baseuri}/{id}";
            return View(new LocationDetailVM
            {
                LocationDetail = GetApiResult<LocationDetail>(LocationUri)
            });
        }

        public IActionResult Delete(int id)
        {
            string LocationUri = $"{baseuri}/{id}";
            return View(new LocationDetailVM
            {
                LocationDetail = GetApiResult<LocationDetail>(LocationUri)
            });
        }

        public IActionResult DeleteDone(int id)
        {
            string LocationUri = $"{baseuri}/{id}";
            DeleteApiLocationAsync<Location>(LocationUri);
            return View();
        }

        public IActionResult Insert()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit()
        {
            int id = int.Parse(Request.Form["LocationDetail.id"]);
            string name = Request.Form["LocationDetail.name"].ToString();
            var description = Request.Form["LocationDetail.description"].ToString();
            var backgroundColor = Request.Form["LocationDetail.backgroundColor"].ToString();
            string locationUri = $"{baseuri}/{id}";
            Location location = GetApiResult<Location>(locationUri);
            Location loc = new Location
            {
                Id = id,
                turnedOn = location.turnedOn,
                backgroundColor = backgroundColor,
                bluetoothOff = location.bluetoothOff,
                coordinates = location.coordinates,
                description = description,
                name = name,
                silent = location.silent,
                vibrate = location.vibrate,
            };
            PutApiLocationAsync<Location>(locationUri, loc);

            string LocationUri = $"{baseuri}/{id}";
            return View("Detail", new LocationDetailVM
            {
                LocationDetail = GetApiResult<LocationDetail>(LocationUri)
            });

        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Insert(string add)
        {
            //TO DO: save new location
            string name = Request.Form["LocationDetail.name"].ToString();
            var description = Request.Form["LocationDetail.description"].ToString();
            var backgroundColor = Request.Form["LocationDetail.backgroundColor"].ToString();
            Location loc = new Location
            {
                turnedOn = true,
                backgroundColor = backgroundColor,
                bluetoothOff = false,
                coordinates = "51.20390,3.21558",
                description = description,
                name = name,
                silent = true,
                vibrate = false,
            };
            PostApiLocationAsync<Location>(loc);

            string locationUri = $"{baseuri}/simple";
            return View("Index",GetApiResult<List<LocationSimple>>(locationUri));
        } //to do

        public IActionResult ToggleTurnedOnIndex(int id, bool val)
        {
            string locationUri = $"{baseuri}/{id}";
            Location location = GetApiResult<Location>(locationUri);
            Location loc = new Location
            {
                Id = id,
                turnedOn = !val,
                backgroundColor = location.backgroundColor,
                bluetoothOff = location.bluetoothOff,
                coordinates = location.coordinates,
                description = location.description,
                name = location.name,
                silent = location.silent,
                vibrate = location.vibrate,
            };
            PutApiLocationAsync<Location>(locationUri, loc);
            locationUri = $"{baseuri}/simple";
            return View("Index", GetApiResult<List<LocationSimple>>(locationUri));
        }

        public IActionResult ToggleTurnedOnDetail(int id, bool val)
        {
            string locationUri = $"{baseuri}/{id}";
            Location location = GetApiResult<Location>(locationUri);
            Location loc = new Location
            {
                Id = id,
                turnedOn = !val,
                backgroundColor = location.backgroundColor,
                bluetoothOff = location.bluetoothOff,
                coordinates = location.coordinates,
                description = location.description,
                name = location.name,
                silent = location.silent,
                vibrate = location.vibrate,
            };
            PutApiLocationAsync<Location>(locationUri, loc);
             
            locationUri = $"{baseuri}/{id}";
            return View("Detail",new LocationDetailVM
            {
                LocationDetail = GetApiResult<LocationDetail>(locationUri)
            });
        }

        public IActionResult ToggleSilent(int id, bool val)
        {
            string locationUri = $"{baseuri}/{id}";
            Location location = GetApiResult<Location>(locationUri);
            Location loc = new Location
            {
                Id = id,
                turnedOn = location.turnedOn,
                backgroundColor = location.backgroundColor,
                bluetoothOff = location.bluetoothOff,
                coordinates = location.coordinates,
                description = location.description,
                name = location.name,
                silent = !val,
                vibrate = location.vibrate,
            };
            PutApiLocationAsync<Location>(locationUri, loc);

            locationUri = $"{baseuri}/{id}";
            return View("Detail", new LocationDetailVM
            {
                LocationDetail = GetApiResult<LocationDetail>(locationUri)
            });
        }

        public IActionResult ToggleBluetoothOff(int id, bool val)
        {
            string locationUri = $"{baseuri}/{id}";
            Location location = GetApiResult<Location>(locationUri);
            Location loc = new Location
            {
                Id = id,
                turnedOn = location.turnedOn,
                backgroundColor = location.backgroundColor,
                bluetoothOff = !val,
                coordinates = location.coordinates,
                description = location.description,
                name = location.name,
                silent = location.silent,
                vibrate = location.vibrate,
            };
            PutApiLocationAsync<Location>(locationUri, loc);

            locationUri = $"{baseuri}/{id}";
            return View("Detail", new LocationDetailVM
            {
                LocationDetail = GetApiResult<LocationDetail>(locationUri)
            });
        }

        public IActionResult ToggleVibrate(int id, bool val)
        {
            string locationUri = $"{baseuri}/{id}";
            Location location = GetApiResult<Location>(locationUri);
            Location loc = new Location
            {
                Id = id,
                turnedOn = location.turnedOn,
                backgroundColor = location.backgroundColor,
                bluetoothOff = location.bluetoothOff,
                coordinates = location.coordinates,
                description = location.description,
                name = location.name,
                silent = location.silent,
                vibrate = !val,
            };
            PutApiLocationAsync<Location>(locationUri, loc);

            locationUri = $"{baseuri}/{id}";
            return View("Detail", new LocationDetailVM
            {
                LocationDetail = GetApiResult<LocationDetail>(locationUri)
            });
        }

        public void PostApiLocationAsync<T>(Location loc)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var response = httpClient.PostAsync("https://localhost:5001/api/locations", loc, new JsonMediaTypeFormatter()).Result;
                if (response.IsSuccessStatusCode)
                {
                    Console.Write("succes");
                }
                else
                    Console.Write("Error");
            }
        }
        public void PutApiLocationAsync<T>(string uri, Location loc)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var response = httpClient.PutAsync(uri, loc, new JsonMediaTypeFormatter()).Result;
                if (response.IsSuccessStatusCode)
                {
                    Console.Write("succes");
                }
                else
                    Console.Write("Error");
            }
        }
        public void DeleteApiLocationAsync<T>(string uri)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var response = httpClient.DeleteAsync(uri).Result;
                if (response.IsSuccessStatusCode)
                {
                    Console.Write("succes");
                }
                else
                    Console.Write("Error");
            }
        }
        public T GetApiResult<T>(string uri)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                Task<String> response = httpClient.GetStringAsync(uri);
                return Task.Factory.StartNew
                    (
                        () => JsonConvert
                            .DeserializeObject<T>(response.Result)
                    ).Result;
            }
        }
    }
}