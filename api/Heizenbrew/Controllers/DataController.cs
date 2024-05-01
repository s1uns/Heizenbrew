using ClosedXML.Excel;
using Core;
using DAL;
using heisenbrew_api.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace heisenbrew_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController
    {
        private readonly ApplicationDbContext _context;

        public DataController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Exports project data in .xlsx format.
        /// </summary>
        /// <remarks>
        /// If the operation is successful, it will return an .xlsx file.
        /// </remarks>
        /// <returns>An IActionResult representing the result of the operation.</returns>
        [HttpGet("/export")]
        [Authorize(Roles = nameof(Roles.Administrator))]
        [FileDownload(FileName = "DbSaved.xlsx")]
        public async Task<IActionResult> ExportData()
        {
            var brewers = _context.Brewers.ToList();
            var brewerEquipment = _context.BrewerBrewingEquipment.ToList();
            var brewerIngredients = _context.BrewerIngredients.ToList();
            var brewingEquipment = _context.BrewingEquipment.ToList();
            var brewings = _context.Brewings.ToList();
            var ingredients = _context.Ingredients.ToList();
            var recipes = _context.Recipes.ToList();
            var recipeIngredientss = _context.RecipeIngredients.ToList();
            var votes = _context.Votes.ToList();

            using (var workbook = new XLWorkbook())
            {
                AddWorksheet(workbook, "Brewers", brewers);
                AddWorksheet(workbook, "BrewerBrewingEquipment", brewerEquipment);
                AddWorksheet(workbook, "BrewerIngredients", brewerIngredients);
                AddWorksheet(workbook, "BrewingEquipment", brewingEquipment);
                AddWorksheet(workbook, "Brewings", brewings);
                AddWorksheet(workbook, "Ingredients", ingredients);
                AddWorksheet(workbook, "Recipes", recipes);
                AddWorksheet(workbook, "RecipeIngredients", recipeIngredientss);
                AddWorksheet(workbook, "Votes", votes);

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return new FileContentResult(content, "application/vnd.ms-excel");
                }
            }
        }

        private void AddWorksheet<T>(IXLWorkbook workbook, string worksheetName, IList<T> data)
        {
            var worksheet = workbook.Worksheets.Add(worksheetName);
            worksheet.Cell(1, 1).InsertTable(data);
        }
    }
}
