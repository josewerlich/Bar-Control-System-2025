using Bar_Control_System_2025.Domain.TableModule;
using Bar_Control_System_2025.Infrastructure.Files.Shared;
using Bar_Control_System_2025.Infrastructure.Files.TableModule;
using Bar_Control_System_2025.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bar_Control_System_2025.WebApp.Controllers;
//{
//   // public class TableController : Controller
//    {
//        private readonly ProductRepositoryInFile tableRepository;

//        public TableController(ProductRepositoryInFile tableRepository)
//        {
//            this.tableRepository = tableRepository;
//        }
//        public IActionResult Index()
//        {
//            List<Table> tables = tableRepository.SelectRegister();

//           TableViewModels viewModels = new TableViewModels(tables); 

//            return View(viewModels);
//        }
//        [HttpGet]
//        public IActionResult Add()
//        {
//            AddTableViewModel addTableViewModel = new AddTableViewModel();

//            return View(addTableViewModel);
//        }
//        [HttpPost]
//        public IActionResult Add(AddTableViewModel addTableViewModel)
//        {
//           if(!ModelState.IsValid)
//            {
//                return View(addTableViewModel);
//            }

//            var entity = new Table(addTableViewModel.TableNumber, addTableViewModel.TableSize);

//            tableRepository.AddRegister(entity);

//            return RedirectToAction(nameof(Index));
//        }

//        [HttpGet]
//        public IActionResult Edit(int id)
//        {
//            var register = tableRepository.SelectRegisterID(id);

//            EditTableViewModel editTableViewModel = new EditTableViewModel(
//                id,
//                register.TableNumber,
//                register.TableSize
//                );
//            return View(editTableViewModel);
//        }
//        [HttpPost]
//        public IActionResult Edit(EditTableViewModel editTableViewModel)
//        {
//           if(!ModelState.IsValid)
//            {
//                return View(editTableViewModel);
//            }

//           var selectedTable = new Table(editTableViewModel.TableNumber, editTableViewModel.TableSize);

//            tableRepository.EditRegister(editTableViewModel.Id, selectedTable);
//            return RedirectToAction(nameof(Index));
//        }
//        [HttpGet]
//        public IActionResult Delete(int id)
//        {
//            var register = tableRepository.SelectRegisterID(id);

//            DeleteTableViewModel deleteTableViewModel = new DeleteTableViewModel(
//                id,
//                register.TableNumber
//               );

//            return View(deleteTableViewModel);
//        }

//        [HttpPost]
//        public IActionResult Delete(DeleteTableViewModel deleteTableViewModel)
//        {
            
//            tableRepository.DeleteRegister(deleteTableViewModel.Id);
//            return RedirectToAction(nameof(Index));
//        }
//    }
//}
