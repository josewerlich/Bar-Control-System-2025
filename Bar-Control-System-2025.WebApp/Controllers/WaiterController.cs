using Bar_Control_System_2025.Domain.WaiterModule;
using Bar_Control_System_2025.Infrastructure.Files.Shared;
using Bar_Control_System_2025.Infrastructure.Files.WaiterRepositoryInFile;
using Bar_Control_System_2025.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bar_Control_System_2025.WebApp.Controllers;
public class WaiterController : Controller
{
    private readonly WaiterRepositoryInFile waiterRepository;

public WaiterController(WaiterRepositoryInFile waiterRepository)
{
    this.waiterRepository = waiterRepository;
}
public IActionResult Index()
{
    List<Waiter> waiters = waiterRepository.SelectRegister();

    WaiterViewModels viewModels = new WaiterViewModels(waiters);

        return View(viewModels);
}
[HttpGet]
public IActionResult Add()
{
    AddWaiterViewModel addWaiterViewModel = new AddWaiterViewModel();

    return View(addWaiterViewModel);
}
[HttpPost]
public IActionResult Add(AddWaiterViewModel addWaiterViewModel)
{
    if (!ModelState.IsValid)
    {
        return View(addWaiterViewModel);
    }

    var entity = new Waiter(addWaiterViewModel.Name, addWaiterViewModel.SSN);

    waiterRepository.AddRegister(entity);

    return RedirectToAction(nameof(Index));
}

[HttpGet]
public IActionResult Edit(int id)
{
    var register = waiterRepository.SelectRegisterID(id);

    EditWaiterViewModel editWaiterViewModel = new EditWaiterViewModel(
        id,
        register.Name,
        register.SSN
        );
        return View(editWaiterViewModel); 
}
[HttpPost]
public IActionResult Edit(EditWaiterViewModel editWaiterViewModel)
{
    if (!ModelState.IsValid)
    {
        return View(editWaiterViewModel);
    }

    var selectedWaiter = new Waiter(editWaiterViewModel.Name, editWaiterViewModel.SSN);

    waiterRepository.EditRegister(editWaiterViewModel.Id, selectedWaiter);
    return RedirectToAction(nameof(Index));
}
[HttpGet]
public IActionResult Delete(int id)
{
    var register = waiterRepository.SelectRegisterID(id);

    DeleteWaiterViewModel deleteTableViewModel = new DeleteWaiterViewModel(
        id,
        register.Name
       );

    return View(deleteTableViewModel);
}

[HttpPost]
public IActionResult Delete(DeleteWaiterViewModel deleteWaiterViewModel)
{

    waiterRepository.DeleteRegister(deleteWaiterViewModel.Id);
    return RedirectToAction(nameof(Index));
}

}
