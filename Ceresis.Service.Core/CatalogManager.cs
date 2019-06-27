﻿using Ceresis.Data.Core.Model;
using Ceresis.Data.Core.Request;
using Ceresis.Data.Core.Response;
using Ceresis.Service.Core.Ext;
using Ceresis.Service.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ceresis.Service.Core
{
    public class CatalogManager
    {
        private readonly DBManager dbManager;
        private readonly IPathProvider pathProvider;

        public CatalogManager(DBManager dbManager, IPathProvider pathProvider)
        {
            this.dbManager = dbManager;
            this.pathProvider = pathProvider;
        }

        public ResponseGetWindowPlastics GetWindows()
        {
            var response = new ResponseGetWindowPlastics();

            try
            {
                var data = dbManager.GetWindowPlastics().ToList();

                var mData = data.Select(d => new WindowPlasticDTO()
                {
                    Feature = d.Feature,
                    Name = d.Name,
                    Size = d.Size,
                    Total = $"{string.Format("{0:#.##}", d.Total)} {(d.HasSetup ? "с установкой" : "без установки")}",
                    TotalValue = d.Total,
                    ImageUrl = d.ImageUrl,
                }).ToList();

                response.Data = mData;
            }
            catch (Exception ex)
            {
                response.IsError = true;
                response.Message = ex.Message;
            }

            return response;
        }

        public ResponseGetSplitHouseCatalog GetSplitHouse()
        {
            var response = new ResponseGetSplitHouseCatalog();

            try
            {
                var data = dbManager.GetSplitHouses().ToList();

                var mData = data.Select(d => new SplitHouseDTO()
                {
                    EnergoEfficienty = d.EnergoEfficienty,
                    ImageUrl = d.ImageUrl,
                    Model = d.Model,
                    Noise = d.Noise,
                    Power = d.Power,
                    PowerRealty = d.PowerRealty,
                    Price = d.Price,
                    SizeExternal = d.SizeExternal,
                    SizeInternal = d.SizeInternal,
                    Id = d.Id
                }).ToList();

                response.Data = mData;
            }
            catch (Exception ex)
            {
                response.IsError = true;
                response.Message = ex.Message;
            }

            return response;
        }

        public ResponseGetWorkpriceCatalog GetWorkpriceCatalog()
        {
            var response = new ResponseGetWorkpriceCatalog();

            try
            {
                var data = dbManager.GetWorkprices().ToList();

                var mData = data.Select(d => new WorkpriceDTO()
                {
                    ContactPrice = d.ContactPrice,
                    ExactPrice = d.ExactPrice,
                    Id = d.Id,
                    Name = d.Name,
                    Price = d.Price,
                    Unity = d.Unity
                }).ToList();

                response.Data = mData;
            }
            catch (Exception ex)
            {
                response.IsError = true;
                response.Message = ex.Message;
            }

            return response;
        }

        public ResponseGetLogos GetLogos()
        {
            var response = new ResponseGetLogos();

            try
            {
                var data = dbManager.GetLogos().ToList();

                var mData = data.Select(d => new LogoDTO() {
                    Description = d.Description,
                    ImageUrl = d.ImageUrl,
                    Name = d.Name,
                    Type = d.Type.GetDescription(),
                    TypeValue = d.Type
                }).ToList();

                response.Data = mData;
            }
            catch (Exception ex)
            {
                response.IsError = true;
                response.Message = ex.Message;
            }

            return response;
        }
    }
}