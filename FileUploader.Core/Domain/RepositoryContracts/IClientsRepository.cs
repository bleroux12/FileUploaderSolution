using FileUploader.Core.Domain.Entities;
using FileUploader.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileUploader.Core.Domain.RepositoryContracts
{
    public interface IClientsRepository
    {
        /// <summary>
        /// Adds a client object to the database
        /// </summary>
        /// <param name="client">Client object to add</param>
        /// <returns>The client object after adding it to the database</returns>
        Task<Client> AddClient(Client client);
        /// <summary>
        /// Returns all the clients in the database
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Client>> GetAllClients();
        /// <summary>
        /// Returns a client object based on the given client id
        /// </summary>
        /// <param name="clientID">ID to be searched</param>
        /// <returns></returns>
        Task<Client?> GetClientByID(Guid clientID);
        /// <summary>
        /// Returns a client object based on the given client name
        /// </summary>
        /// <param name="ClientName">ClientName to be searched</param>
        /// <returns></returns>
        Task<Client?> GetClientByClientName(string ClientName);
        /// <summary>
        /// Removes a clients by setting its IsDeleted to true based on the client id
        /// </summary>
        /// <param name="clientID">clientID</param>
        /// <returns></returns>
        Task<Response> DeleteClient(Guid clientID);
        /// <summary>
        /// Updats client object based on the given client id
        /// </summary>
        /// <param name="client"></param>
        /// <returns>The updated Client object</returns>
        Task<Client?> UpdateClient(Client client);
    }
}
