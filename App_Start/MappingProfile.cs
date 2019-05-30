﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using solo.Models;
using solo.Dtos;

namespace solo.App_Start
    {
    public class MappingProfile: Profile
        {
        public MappingProfile()
            {

            CreateMap<Customer, CustomerDto>();
            CreateMap<CustomerDto, Customer>();
            CreateMap<Movie, MovieDto>();
            CreateMap<MovieDto, Movie>();


            }
        }
    }