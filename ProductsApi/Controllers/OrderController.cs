﻿using Infrastructure;
using ProductServices;
using ProductServices.DTOs;
using ProductServices.DTOs.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ProductsApi.Controllers
{
    [RoutePrefix("orders")]
    public class OrderController : ApiController
    {
        private readonly OrderService orderService;

        private readonly IUnitOfWork Uow;

        public OrderController(OrderService service, IUnitOfWork uow)
        {
            orderService = service;
            Uow = uow;
        }

        [Route("{id:int}")]
        public async Task<IHttpActionResult> GetOrderr(int id)
        {
            return await Task.FromResult(Ok(await orderService.Find(id)));
        }

        [Route("")]
        public async Task<IHttpActionResult> PostOrder(AddOrderRequest dto)
        {
            await orderService.Add(dto);
            Uow.Commit();
            return await Task.FromResult(Ok());
        }
    }
}
