using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NinjaShop.API.Domain;
using NinjaShop.Repository;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;


namespace NinjaShop.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly INinjaShopRepository _repo;

        public ProdutoController(INinjaShopRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var results = await _repo.GetAllProdutoAsync();
                
                return Ok(results);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco Dados Falhou");
            }            
        }

        [HttpGet("{ProdutoId}")]
        public async Task<IActionResult> Get(int ProdutoId)
        {
            try
            {
                var results = await _repo.GetProdutoAsyncById(ProdutoId);
                
                return Ok(results);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco Dados Falhou");
            }            
        }

        // [HttpPost("upload")]
        // public async Task<IActionResult> Upload()
        // {
        //     try
        //     {
        //         var file = Request.Form.Files[0];
        //         var folderName = Path.Combine("Resources", "Images");
        //         var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

        //         if (file.Length > 0)
        //         {
        //             var filename = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName;
        //             var fullPath = Path.Combine(pathToSave, filename.Replace("\"", " ").Trim());

        //             using (var stream = new FileStream(fullPath, FileMode.Create))
        //             {
        //                 file.CopyTo(stream);
        //             }
        //         }

        //         return Ok();
        //     }
        //     catch (System.Exception ex)
        //     {
        //         return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco Dados Falhou {ex.Message}");
        //     }

        //     return BadRequest("Erro ao tentar realizar upload");
        // }

        
        [HttpPost]
        public async Task<IActionResult> Post(Produto model)
        {            
            try
            {
                _repo.Add(model);
                
                if(await _repo.SaveChangesAsync())
                {
                    return Created($"/api/produto/{model.ProdutoId}", model);
                }                
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco Dados Falhou");
            }   

            return BadRequest();         
        }

        [HttpPut("{ProdutoId}")]
        public async Task<IActionResult> Put(int ProdutoId, Produto model)
        {
            try
            {
                var produto = await _repo.GetProdutoAsyncById(ProdutoId);
                if(produto == null) return NotFound();

                _repo.Update(model);
                
                if(await _repo.SaveChangesAsync())
                {
                    return Created($"/api/produto/{model.ProdutoId}", model);
                }                
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco Dados Falhou");
            }   

            return BadRequest();         
        }

        [HttpDelete("{ProdutoId}")]
        public async Task<IActionResult> Delete(int ProdutoId)
        {
            try
            {
                var produto = await _repo.GetProdutoAsyncById(ProdutoId);
                if(produto == null) return NotFound();

                _repo.Delete(produto);
                
                if(await _repo.SaveChangesAsync())
                {
                    return Ok();
                }                
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco Dados Falhou");
            }   

            return BadRequest();         
        }
    }
        
    }