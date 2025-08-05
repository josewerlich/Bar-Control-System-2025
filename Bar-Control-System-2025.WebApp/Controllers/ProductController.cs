using Bar_Control_System_2025.Domain.ProductsModule;
using Bar_Control_System_2025.Infrastructure.Files.ProductRepositoryInFile;
using Bar_Control_System_2025.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bar_Control_System_2025.WebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductReposirotyInFile productRepository;

        public ProductController(ProductReposirotyInFile productRepository)
        {
            this.productRepository = productRepository;
        }
        public IActionResult Index()
        {
            List<Product> products = productRepository.SelectRegister();

            ProductViewModels viewModels = new ProductViewModels(products); 

            return View(viewModels);
        }
        [HttpGet]
        public IActionResult Add()
        {
            AddProductViewModel addProductViewModel = new AddProductViewModel();

            return View(addProductViewModel);
        }
        [HttpPost]
        public IActionResult Add(AddProductViewModel addProductViewModel)
        {
           if(!ModelState.IsValid)
            {
                return View(addProductViewModel);
            }

            var entity = new Product(addProductViewModel.Name, addProductViewModel.Cost);

            productRepository.AddRegister(entity);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var register = productRepository.SelectRegisterID(id);

            EditProductViewModel editProductViewModel = new EditProductViewModel(
                id,
                register.Name,
                register.Cost
                );
            return View(editProductViewModel);
        }
        [HttpPost]
        public IActionResult Edit(EditProductViewModel editProductViewModel)
        {
           if(!ModelState.IsValid)
            {
                return View(editProductViewModel);
            }

           var selectedProduct = new Product(editProductViewModel.Name, editProductViewModel.Cost);

            productRepository.EditRegister(editProductViewModel.Id, selectedProduct);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var register = productRepository.SelectRegisterID(id);

            DeleteProductViewModel deleteProductViewModel = new DeleteProductViewModel(
                id,
                register.Name
               );

            return View(deleteProductViewModel);
        }

        [HttpPost]
        public IActionResult Delete(DeleteProductViewModel deleteProductViewModel)
        {
            
            productRepository.DeleteRegister(deleteProductViewModel.Id);
            return RedirectToAction(nameof(Index));
        }
    }
}
