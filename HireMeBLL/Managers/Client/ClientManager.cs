﻿using HireMeBLL.Dtos.Client;
using HireMeDAL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeBLL
{
    public class ClientManager : IClientManager
    {
        private readonly IClientRepo _clientRepo;
        private readonly ISystemUserRepo _systemUserRepo;

        public ClientManager(IClientRepo clientRepo,ISystemUserRepo systemUserRepo)
        {
            this._clientRepo = clientRepo;
            this._systemUserRepo = systemUserRepo;
        }
        public async Task<bool> CreateClient(ReigsterClientDto clientData)
        {

            Client client = new Client() 
            {
                FirstName = clientData.FirstName,
                LastName=clientData.Lastname,
                Email = clientData.Email,
                UserName = clientData.UserName,
                Balance=0,
                TotalMoneySpent=0,

            };
          var CreateResult= await _clientRepo.CreateClient(client, clientData.Password);

            return CreateResult;


        }

        public async Task<bool> deleteClient(string id)
        {
           return await _clientRepo.DeleteClient(id);
        }

        public List<ClientDto> GetAllClients()
        {
           return _clientRepo.GetAllClient().Select(c=> new ClientDto(c.Id,c.FirstName,c.LastName,c.UserName,
               c.Country,c.City,c.Street,c.Image,c.Age,c.SSN,c.Balance,
               c.PaymentMethodId,c.PlanId,c.TotalMoneySpent,c.Email,c.PhoneNumber)).ToList();
        }

        public async Task<ClientDto> GetClientById(string id)
        {
           var clientToBeReturned = await _clientRepo.GetClientById(id);
            if (clientToBeReturned != null)
                return new ClientDto(clientToBeReturned.Id, clientToBeReturned.FirstName, clientToBeReturned.LastName, clientToBeReturned.UserName,
                    clientToBeReturned.Country, clientToBeReturned.City, clientToBeReturned.Street, clientToBeReturned.Image,
                   clientToBeReturned.Age, clientToBeReturned.SSN,
                   clientToBeReturned.Balance, clientToBeReturned.PaymentMethodId,
                   clientToBeReturned.PlanId, clientToBeReturned.TotalMoneySpent,clientToBeReturned.Email,clientToBeReturned.PhoneNumber);
            return null;
        }

        public ClientCountDto GetClientsCount()
        {
            ClientCountDto countDto= new ClientCountDto();
            countDto.ClientCount = _clientRepo.GetAllClient().Count();
            return countDto;
        }

        public async Task<TokenDto> Login(LoginDto loginCred)
        {
            var token= await _systemUserRepo.Login(loginCred.Email, loginCred.Password);

            if (token!=null)
            {
            return new TokenDto() { Token = token.token, ExpiryDate = token.Expiry, Roles = token.Roles };

            }else return new TokenDto();
        }

        public async Task<bool> UpdateClient(UpdateClientDto clientDto)
        {
            //need to separate the update of those 3 
            var client = new Client()
            {
                Id = clientDto.Id,
                FirstName = clientDto.FirstName,
                LastName = clientDto.LastName,
                Country = clientDto.Country,
                City = clientDto.City,
                Street = clientDto.Street,
                Image = Helper.ConvertFromFileToByteArray(clientDto.Image),
                Age = clientDto.Age,
                SSN = clientDto.SSN,
                PaymentMethodId = clientDto.PaymentMethodId,
                CategoryId= clientDto.CategoryId,
                Email=clientDto.email,
                UserName=clientDto.Username,
                PhoneNumber=clientDto.PhoneNumber,
                
            };
            return await _clientRepo.UpdateClient(client);


        }

        public async Task<bool> UpdateClientMoney(Client currentClient)
        {
            return await _clientRepo.UpdateClient(currentClient);
        }
    }
}
