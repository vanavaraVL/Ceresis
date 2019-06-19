using Ceresis.Data.Core.Model;
using Ceresis.Data.Core.Request;
using Ceresis.Data.Core.Response;
using Ceresis.Repository.Models;
using Ceresis.Service.Core.Ext;
using Ceresis.Service.Core.Helpers;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Ceresis.Service.Core
{
    public class AdminManager
    {
        private readonly DBManager dbManager;
        private readonly IPathProvider pathProvider;

        private const string WORKPLACE_DIRECTORY = "workplace";
        private const string CATALOG_DIRECTORY = "catalog";

        public AdminManager(DBManager dbManager, IPathProvider pathProvider)
        {
            this.dbManager = dbManager;
            this.pathProvider = pathProvider;
        }

        public ResponseGetAllWorkSamples GetWorkSamples(RequestGetWorkSamples request = null)
        {
            var response = new ResponseGetAllWorkSamples(request?.Paging);

            try
            {
                var data = dbManager.GetWorksamples();

                var result = data.Sorting(request?.Sorting).Pagination(response.Paging).ToList();

                var cData = result.Select(t => new WorkSample() { Description = t.Description, ImageName = t.ImageName, ImagePath = t.ImagePath, Id = t.Id }).ToList();

                response.Data = cData;

            }
            catch (Exception ex)
            {
                response.IsError = true;
                response.Message = ex.Message;
            }

            return response;
        }

        public ResponseGetLogos GetLogos(RequestGetLogos request = null)
        {
            var response = new ResponseGetLogos(request?.Paging);

            try
            {
                var data = dbManager.GetLogos();

                var result = data.Sorting(request?.Sorting).Pagination(response.Paging).ToList();

                var cData = result.Select(t => new LogoDTO()
                {
                    Description = t.Description,
                    Id = t.Id,
                    ImageUrl = t.ImageUrl,
                    Name = t.Name,
                    Type = t.Type.GetDescription(),
                    TypeValue = t.Type
                }).ToList();

                response.Data = cData;

            }
            catch (Exception ex)
            {
                response.IsError = true;
                response.Message = ex.Message;
            }

            return response;
        }

        public ResponseGetWindowPlastics GetWindowPlastics(RequestGetWindowPlastics request)
        {
            var response = new ResponseGetWindowPlastics(request?.Paging);

            try
            {
                var data = dbManager.GetWindowPlastics();

                var result = data.Sorting(request?.Sorting).Pagination(response.Paging).ToList();

                var cData = result.Select(t => new WindowPlasticDTO() {
                    Id = t.Id,
                    Feature = t.Feature,
                    ImageUrl = t.ImageUrl,
                    Name = t.Name,
                    Size = t.Size,
                    TotalValue = t.Total,
                    HasSetup = t.HasSetup,
                    Total = $"{string.Format("{0:#.##}", t.Total)} {(t.HasSetup ? "с установкой" : "без установки")}",
                }).ToList();

                response.Data = cData;

            }
            catch (Exception ex)
            {
                response.IsError = true;
                response.Message = ex.Message;
            }

            return response;
        }

        public ResponseGetSplitHouseCatalog GetSplitHouses(RequestGetSplitHouseCatalog request)
        {
            var response = new ResponseGetSplitHouseCatalog(request?.Paging);

            try
            {
                var data = dbManager.GetSplitHouses();

                var result = data.Sorting(request?.Sorting).Pagination(response.Paging).ToList();

                var cData = result.Select(t => new SplitHouseDTO()
                {
                    Id = t.Id,
                    EnergoEfficienty = t.EnergoEfficienty,
                    ImageUrl = t.ImageUrl,
                    Model = t.Model,
                    Noise = t.Noise,
                    Power = t.Power,
                    PowerRealty = t.PowerRealty,
                    Price = t.Price,
                    SizeExternal = t.SizeExternal,
                    SizeInternal = t.SizeInternal
                }).ToList();

                response.Data = cData;

            }
            catch (Exception ex)
            {
                response.IsError = true;
                response.Message = ex.Message;
            }

            return response;
        }

        public ResponseGetWorkpriceCatalog GetWorkprices(RequestGetWorkprice request)
        {
            var response = new ResponseGetWorkpriceCatalog(request?.Paging);

            try
            {
                var data = dbManager.GetWorkprices();

                var result = data.Sorting(request?.Sorting).Pagination(response.Paging).ToList();

                var cData = result.Select(t => new WorkpriceDTO()
                {
                    ContactPrice = t.ContactPrice,
                    ExactPrice = t.ExactPrice,
                    Id = t.Id,
                    Name = t.Name,
                    Price = t.Price,
                    Unity = t.Unity
                }).ToList();

                response.Data = cData;

            }
            catch (Exception ex)
            {
                response.IsError = true;
                response.Message = ex.Message;
            }

            return response;
        }

        public ResponseDeleteWorkSample DeleteWorkSample(int id)
        {
            var response = new ResponseDeleteWorkSample();


            try
            {
                dbManager.RemoveWorkSample(id);
            }
            catch (Exception ex)
            {
                response.IsError = true;
                response.Message = ex.Message;
            }

            return response;
        }

        public ResponseDeleteLogo DeleteLogo(int id)
        {
            var response = new ResponseDeleteLogo();


            try
            {
                dbManager.RemoveLogo(id);
            }
            catch (Exception ex)
            {
                response.IsError = true;
                response.Message = ex.Message;
            }

            return response;
        }

        public ResponseDeleteSplitHouse DeleteSplitHouse(int id)
        {
            var response = new ResponseDeleteSplitHouse();


            try
            {
                dbManager.RemoveSplitHouse(id);
            }
            catch (Exception ex)
            {
                response.IsError = true;
                response.Message = ex.Message;
            }

            return response;
        }

        public ResponseDeleteWorkprice DeleteWorkprice(int id)
        {
            var response = new ResponseDeleteWorkprice();


            try
            {
                dbManager.RemoveWorkprice(id);
            }
            catch (Exception ex)
            {
                response.IsError = true;
                response.Message = ex.Message;
            }

            return response;
        }

        public ResponseDeleteWindow DeleteWindow(int id)
        {
            var response = new ResponseDeleteWindow();


            try
            {
                dbManager.RemoveWindowPlastic(id);
            }
            catch (Exception ex)
            {
                response.IsError = true;
                response.Message = ex.Message;
            }

            return response;
        }

        public ResponseAddNewWorksample AddWorksample(RequestAddNewWorksample request)
        {
            var response = new ResponseAddNewWorksample();

            try
            {
                var imagePath = SaveImageToWorksampleDirectory(request.FileName, request.FileData, WORKPLACE_DIRECTORY);

                var item = new WorkExample()
                {
                    Description = request.Description,
                    ImageName = request.FileName,
                    ImagePath = imagePath
                };

                dbManager.AddNewWorksample(item);
            }
            catch (Exception ex)
            {
                response.IsError = true;
                response.Message = ex.Message;
            }

            return response;
        }

        public ResponseAddLogo AddLogo(RequestAddLogo request)
        {
            var response = new ResponseAddLogo();

            try
            {
                var imagePath = SaveImageToWorksampleDirectory(request.FileName, request.FileData, CATALOG_DIRECTORY);

                var item = new LogoType()
                {
                    Description = request.Description,
                    ImageUrl = imagePath,
                    Name = request.Name,
                    Type = request.TypeValue
                };

                dbManager.AddLogo(item);
            }
            catch (Exception ex)
            {
                response.IsError = true;
                response.Message = ex.Message;
            }

            return response;
        }

        public ResponseAddSplitHouse AddSplitHouse(RequestAddSplitHouse request)
        {
            var response = new ResponseAddSplitHouse();

            try
            {
                var imagePath = SaveImageToWorksampleDirectory(request.FileName, request.FileData, CATALOG_DIRECTORY);

                var item = new SplitHouse()
                {
                    ImageUrl = imagePath,
                    EnergoEfficienty = request.EnergoEfficienty,
                    Model = request.Model,
                    Noise = request.Noise,
                    Power = request.Power,
                    PowerRealty = request.PowerRealty,
                    Price = request.Price,
                    SizeExternal = request.SizeExternal,
                    SizeInternal = request.SizeInternal
                };

                dbManager.AddNewSplitHouse(item);
            }
            catch (Exception ex)
            {
                response.IsError = true;
                response.Message = ex.Message;
            }

            return response;
        }

        public ResponseAddWorkprice AddWorkprice(RequestAddWorkprice request)
        {
            var response = new ResponseAddWorkprice();

            try
            {
                var item = new WorkPrice()
                {
                    ContactPrice = request.ContactPrice,
                    ExactPrice = request.ExactPrice,
                    Name = request.Name,
                    Price = request.Price,
                    Unity = request.Unity
                };

                dbManager.AddWorkprice(item);
            }
            catch (Exception ex)
            {
                response.IsError = true;
                response.Message = ex.Message;
            }

            return response;
        }

        public ResponseAddWindow AddWindow(RequestAddWindow request)
        {
            var response = new ResponseAddWindow();

            try
            {
                var imagePath = SaveImageToWorksampleDirectory(request.FileName, request.FileData, CATALOG_DIRECTORY);

                var item = new WindowPlastic()
                {
                    Feature = request.Feature,
                    HasSetup = request.HasSetup,
                    ImageUrl = imagePath,
                    Name = request.Name,
                    Size = request.Size,
                    Total = request.Total
                };

                dbManager.AddNewWindowPlastics(item);
            }
            catch (Exception ex)
            {
                response.IsError = true;
                response.Message = ex.Message;
            }

            return response;
        }

        public ResponseUpdateWindow UpdateWindow(int id, RequestUpdateWindow request)
        {
            var response = new ResponseUpdateWindow();

            try
            {
                var imagePath = string.Empty;

                if (!(string.IsNullOrEmpty(request.FileData) || string.IsNullOrEmpty(request.FileName)))
                    imagePath = SaveImageToWorksampleDirectory(request.FileName, request.FileData, CATALOG_DIRECTORY);

                var windowItem = dbManager.GetById(id);
                if (windowItem == null)
                    throw new Exception("Не найдено ПВХ окно в БД");

                windowItem.Name = request.Name;
                windowItem.Feature = request.Feature;
                windowItem.HasSetup = request.HasSetup;

                if (!string.IsNullOrEmpty(imagePath))
                {
                    windowItem.ImageUrl = imagePath;
                }

                windowItem.Size = request.Size;
                windowItem.Total = request.Total;

                dbManager.UpdateWindowPlastic(windowItem);
            }
            catch (Exception ex)
            {
                response.IsError = true;
                response.Message = ex.Message;
            }

            return response;
        }

        public ResponseUpdateSplitHouse UpdateSplitHouse(int id, RequestUpdateSplitHouse request)
        {
            var response = new ResponseUpdateSplitHouse();

            try
            {
                var imagePath = string.Empty;

                if (!(string.IsNullOrEmpty(request.FileData) || string.IsNullOrEmpty(request.FileName)))
                    imagePath = SaveImageToWorksampleDirectory(request.FileName, request.FileData, CATALOG_DIRECTORY);

                var splitHouseItem = dbManager.GetSplitHouseById(id);
                if (splitHouseItem == null)
                    throw new Exception("Не найдена Сплит-система в БД");

                splitHouseItem.EnergoEfficienty = request.EnergoEfficienty;
                splitHouseItem.Model = request.Model;
                splitHouseItem.Noise = request.Noise;
                splitHouseItem.Power = request.Power;
                splitHouseItem.PowerRealty = request.PowerRealty;
                splitHouseItem.Price = request.Price;
                splitHouseItem.SizeExternal = request.SizeExternal;
                splitHouseItem.SizeInternal = request.SizeInternal;

                if (!string.IsNullOrEmpty(imagePath))
                {
                    splitHouseItem.ImageUrl = imagePath;
                }

                dbManager.UpdateSplitHouse(splitHouseItem);
            }
            catch (Exception ex)
            {
                response.IsError = true;
                response.Message = ex.Message;
            }

            return response;
        }

        public ResponseUpdateWorkprice UpdateWorkprice(int id, RequestUpdateWorkprice request)
        {
            var response = new ResponseUpdateWorkprice();

            try
            {
                var workpriceItem = dbManager.GetWorkpriceById(id);
                if (workpriceItem == null)
                    throw new Exception("Не найдена работа в БД");

                workpriceItem.ContactPrice = request.ContactPrice;
                workpriceItem.ExactPrice = request.ExactPrice;
                workpriceItem.Name = request.Name;
                workpriceItem.Price = request.Price;
                workpriceItem.Unity = request.Unity;

                dbManager.UpdateWorkprice(workpriceItem);
            }
            catch (Exception ex)
            {
                response.IsError = true;
                response.Message = ex.Message;
            }

            return response;
        }

        private string SaveImageToWorksampleDirectory(string fileName, string base64fileContent, string directory)
        {
            var workplaceDirectory = pathProvider.MapPath(Path.Combine("images", directory));

            if (!Directory.Exists(workplaceDirectory))
            {
                Directory.CreateDirectory(workplaceDirectory);
            }

            var fileContent = GetFileContentFromBase64(base64fileContent);

            using (FileStream fs = File.Create(Path.Combine(workplaceDirectory, fileName), fileContent.Length, FileOptions.None))
            {
                fs.Write(fileContent, 0, fileContent.Length);
            }

            return $"/images/{directory}/{fileName}";
        }

        private byte[] GetFileContentFromBase64(string fileContentBase64)
        {
            string base64 = ";base64,";
            int strPosition = fileContentBase64.IndexOf(base64, 0, StringComparison.InvariantCultureIgnoreCase);

            if (strPosition == -1)
                throw new FileNotFoundException("Не удалось получить файл");

            strPosition += base64.Length;
            var fileContent = Convert.FromBase64String(fileContentBase64.Substring(strPosition));

            return fileContent;
        }
    }
}
