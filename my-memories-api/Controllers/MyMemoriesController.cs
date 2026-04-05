
using memories.Domain.Interfaces;
using memories.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace my_memories_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MyMemoriesController : ControllerBase
    {
        private readonly IMemoriesRepository _memoriesRepository;
        public MyMemoriesController(IMemoriesRepository memoriesRepository)
        {
            _memoriesRepository = memoriesRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetMemories()
        {
            var memories = await _memoriesRepository.GetAllAsync();
            return Ok(memories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMemoryById(string id)
        {
            var memory = await _memoriesRepository.GetByIdAsync(id);
            return Ok(memory);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Memory memory)
        {
            await _memoriesRepository.CreateAsync(memory);
            return Ok(memory);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, Memory memory)
        {
            await _memoriesRepository.UpdateAsync(id, memory);
            return Ok(memory);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _memoriesRepository.DeleteAsync(id);
            return Ok();
        }
    }
}