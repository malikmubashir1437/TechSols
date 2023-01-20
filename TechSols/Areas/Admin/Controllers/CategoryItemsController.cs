using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechSols.Data;
using TechSols.Entities;

namespace TechSols.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class CategoryItemsController : Controller
	{
		private readonly ApplicationDbContext _context;

		public CategoryItemsController(ApplicationDbContext context)
		{
			_context = context;
		}

		// GET: Admin/CategoryItems
		public async Task<IActionResult> Index(int categoryId)
		{

			List<CategoryItem> list = await (from catItem in _context.CategoryItem
											 where catItem.CategoryId == categoryId
											 select new CategoryItem
											 {
												 Id = catItem.Id,
												 Title = catItem.Title,
												 Description = catItem.Description,
												 DateTimeItemReleased = catItem.DateTimeItemReleased,
												 MediaTypeId = catItem.MediaTypeId,
												 CategoryId = categoryId
											 }).ToListAsync();


			ViewBag.CategoryId = categoryId;

			return View(list);
		}

		// GET: Admin/CategoryItems/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null || _context.CategoryItem == null)
			{
				return NotFound();
			}

			var categoryItem = await _context.CategoryItem
				.FirstOrDefaultAsync(m => m.Id == id);
			if (categoryItem == null)
			{
				return NotFound();
			}

			return View(categoryItem);
		}

		// GET: Admin/CategoryItems/Create
		public IActionResult Create()
		{
			return View();
		}

		// POST: Admin/CategoryItems/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(CategoryItem categoryItem)
		{
			if (ModelState.IsValid)
			{
				_context.Add(categoryItem);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			return View(categoryItem);
		}

		// GET: Admin/CategoryItems/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null || _context.CategoryItem == null)
			{
				return NotFound();
			}

			var categoryItem = await _context.CategoryItem.FindAsync(id);
			if (categoryItem == null)
			{
				return NotFound();
			}
			return View(categoryItem);
		}

		// POST: Admin/CategoryItems/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, CategoryItem categoryItem)
		{
			if (id != categoryItem.Id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(categoryItem);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!CategoryItemExists(categoryItem.Id))
					{
						return NotFound();
					}
					else
					{
						throw;
					}
				}
				return RedirectToAction(nameof(Index));
			}
			return View(categoryItem);
		}

		// GET: Admin/CategoryItems/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null || _context.CategoryItem == null)
			{
				return NotFound();
			}

			var categoryItem = await _context.CategoryItem
				.FirstOrDefaultAsync(m => m.Id == id);
			if (categoryItem == null)
			{
				return NotFound();
			}

			return View(categoryItem);
		}

		// POST: Admin/CategoryItems/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			if (_context.CategoryItem == null)
			{
				return Problem("Entity set 'ApplicationDbContext.CategoryItem'  is null.");
			}
			var categoryItem = await _context.CategoryItem.FindAsync(id);
			if (categoryItem != null)
			{
				_context.CategoryItem.Remove(categoryItem);
			}

			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool CategoryItemExists(int id)
		{
			return _context.CategoryItem.Any(e => e.Id == id);
		}
	}
}
