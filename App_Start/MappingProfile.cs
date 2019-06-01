using System;
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

            // Domain to dto

            CreateMap<Customer, CustomerDto>();
            CreateMap<Movie, MovieDto>();
            CreateMap<MembershipType, MembershipDto>();

            // Dto to Domain
            CreateMap<CustomerDto, Customer>()
                .ForMember(c=>c.Id,opt=>opt.Ignore());
            
            CreateMap<MovieDto, Movie>()
                .ForMember(c => c.Id, opt => opt.Ignore()); 
            


            }
        }
    }