using ContactListLab.Model;
using ContactListLab.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ContactListWeb.Controllers;


[ApiController]
[Route("[controller]")]
public class MyController
{
    private readonly IContactRepository _contactRepository;

    public MyController(IContactRepository contactRepository)
    {
        _contactRepository = contactRepository;
    }
    
    [HttpGet] [Route("/search-contacts")]
    public async Task<List<ContactDto>> Search([FromQuery] int search, string searchString)
    {
        return await _contactRepository.SearchContacts(search, searchString);

    }

    [HttpPost]
    [Route("/add-new-contact")]
    public Task AddContact([FromBody] ContactDto contact)
    {
        return _contactRepository.AddContact(contact);
    }

    [HttpGet]
    [Route("/show-all-contacts")]
    public async Task<List<ContactDto>> LastTasks()
    {
        return await _contactRepository.ViewAllContacts();
    }
}