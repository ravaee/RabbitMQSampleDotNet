using MQTest.Extentions;
using MQTest.Producer;
using MQTest.Producer.Impl;

var builder = WebApplication.CreateBuilder(args);

builder.Services.TryToServe();

var app = builder.Build();

app.EndpointsMap();

app.RunApp();


