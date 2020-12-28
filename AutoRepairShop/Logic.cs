using System;
using System.Collections.Generic;

namespace AutoRepairShop
{
    public class Logic
    {
        private List<Service> _services;
        public string errorText;

        public IReadOnlyCollection<Service> Services => _services;

        public Logic()
        {
            _services = new List<Service>();
        }

        public int Count => _services.Count;

        public void AddNewService(Service service)
        {
            if (!(service.name == null))
            {
                if (!_services.Exists(a => a.name == service.name))
                {
                    if (uint.TryParse(service.count, out uint n) && uint.TryParse(service.price, out uint nn) && !(service.count == null) && !(service.price == null))
                    {
                        _services.Add(service);
                        errorText = "";
                    }
                    else
                    {
                        errorText = "Count_and_Price_is_Negative_or_NotNumber";
                    }
                }
                else
                {
                    errorText = "Service_already_exist";
                }
            }
            else
            {
                errorText = "ServiceName_IsNull";
            }

        }

        public void ImportDetails(string name, string count)
        {
            if (!(name == null))
            {
                int id = _services.FindIndex(a => a.name == name);
                if (id >= 0)
                {
                    if (uint.TryParse(count, out uint nn) && !(count == null))
                    {
                        _services[id].count = (Convert.ToInt32(_services[id].count) + Convert.ToInt32(count)).ToString();
                        errorText = "";
                    }

                    else
                    {
                        errorText = "Wrong_count";
                    }

                }
                else
                {
                    errorText = "Service_not_found";
                }
            }
            else
            {
                errorText = "ServiceName_IsNull";
            }

        }

        public void BuyService(string name, string count)
        {
            if (!(name == null))
            {
                int id = _services.FindIndex(a => a.name == name);
                if (id >= 0)
                {
                    if (uint.TryParse(count, out uint nn) && !(count == null))
                    {
                        if (Convert.ToInt32(_services[id].count) >= Convert.ToInt32(count))
                        {
                            _services[id].count = (Convert.ToInt32(_services[id].count) - Convert.ToInt32(count)).ToString();
                            errorText = "";
                        }
                        else
                        {
                            errorText = "Service_NeedMore_Details_Than_Exist";
                        }
                    }
                    else
                    {
                        errorText = "Wrong_count";
                    }
                }
                else
                {
                    errorText = "Service_not_found";
                }
            }
            else
            {
                errorText = "ServiceName_IsNull";
            }
        }

        public bool Exists(Service service)
        {
            return _services.Contains(service);
        }

        public void RemoveIfExists(Service service)
        {
            _services.Remove(service);
        }

        public void RemoveAllWithName(string name)
        {
            if (!(name == null))
            {

                var count = _services.FindAll(a => a.name == name).Count;
                if (count > 0)
                {
                    foreach (var pr in _services.FindAll(a => a.name == name))
                    {
                        _services.Remove(pr);
                        errorText = "";
                    }
                }
                else
                {
                    errorText = "Service_not_found";
                }
            }
            else
            {
                errorText = "ServiceName_IsNull";
            }
        }
    }

}

