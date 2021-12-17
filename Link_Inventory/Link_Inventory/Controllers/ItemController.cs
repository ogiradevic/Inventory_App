using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Link_Inventory.Data;
using Link_Inventory.Models.Repositories;
using Link_Inventory.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Link_Inventory.Controllers
{
    public class ItemController : Controller
    {
        private readonly IItemRepository _itemRepository;
        private readonly IRoomRepository _roomRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly INonSerializedItemRoomRepository _nonSerializedItemRoomRepository;
        private readonly ISerializedItemRepository _serializedItemRepository;
        private readonly IItemUserRepository _itemUserRepository;
        private readonly IItemRoomRepository _itemRoomRepository;
        private readonly IInvoiceItemRepository _invoiceItemRepository;
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly ISupplierRepository _supplierRepository;

        public ItemController(IItemRepository itemRepository, IRoomRepository roomRepository, UserManager<ApplicationUser> userManager, INonSerializedItemRoomRepository nonSerializedItemRoomRepository,
            ISerializedItemRepository serializedItemRepository, IItemUserRepository itemUserRepository, IItemRoomRepository itemRoomRepository, IInvoiceItemRepository invoiceItemRepository, IInvoiceRepository invoiceRepository, ISupplierRepository supplierRepository)
        {
            _itemRepository = itemRepository;
            _roomRepository = roomRepository;
            _userManager = userManager;
            _nonSerializedItemRoomRepository = nonSerializedItemRoomRepository;
            _serializedItemRepository = serializedItemRepository;
            _itemUserRepository = itemUserRepository;
            _itemRoomRepository = itemRoomRepository;
            _invoiceItemRepository = invoiceItemRepository;
            _invoiceRepository = invoiceRepository;
            _supplierRepository = supplierRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AllNonSerializedItems()
        {
            try
            {
                var itemsViewModel = new ItemsViewModel
                {
                    AllNonSerilizedItems = _itemRepository.NonSerializedItems,
                };

                if(itemsViewModel != null)
                {
                    return View(itemsViewModel);
                }
                else
                {
                    return NotFound();
                }
            }
            catch(Exception ex)
            {
                return View(ex.Message);
            }

        }

        public IActionResult Details(int id)
        {
            try
            {
                var itemsViewModel = new ItemsViewModel
                {
                    Item = _itemRepository.GetItemById(id),
                    AllNonSerializedItemsRooms = _nonSerializedItemRoomRepository.AllNonSerializedItemsRooms.Where(ir => ir.ItemId == id),
                    SumItemsRooms = _nonSerializedItemRoomRepository.SumPerRoom(id),
                    AllNonSerializedItemsRoomsById = _nonSerializedItemRoomRepository.AllNonSerliazidedItemsRoomsById(id),
                    TotalAmountPerItemId = _nonSerializedItemRoomRepository.SumAllItemsPerRoom(id),
                    AllInvoiceItemsByItemId = _invoiceItemRepository.GetInvoiceItemsByItemId(id)
                };


                itemsViewModel.Undefined = itemsViewModel.Item.Amount - itemsViewModel.TotalAmountPerItemId;


                var roomsFrom = itemsViewModel.AllNonSerializedItemsRoomsById.Select(i => new
                {
                    Text = i.Room.Name + "-" + i.Room.Branch.Name,
                    Value = i.Room.Id
                }).ToList();

                var roomsFromFinal = roomsFrom.Distinct().ToList();


                var undefinedRoom = _roomRepository.AllRooms.Where(x => x.Name == "Prostorija nije određena").Select(x => new
                {
                    Text = x.Name,
                    Value = x.Id
                });

                foreach(var u in undefinedRoom) {

                    roomsFromFinal.Add(u);
                }

                ViewBag.RoomsFrom = new SelectList(roomsFromFinal, "Value", "Text");

                var roomsTo = _roomRepository.AllRooms.Where(x=> x.Name != "Prostorija nije određena").Select(i => new
                {
                    Text = i.Name + "-" + i.Branch.Name,
                    Value = i.Id
                }).ToList();

                ViewBag.RoomsTo = new SelectList(roomsTo, "Value", "Text");

                if (itemsViewModel != null)
                {
                    return View(itemsViewModel);
                }
                else
                {
                    return NotFound();
                }
            }
            catch(Exception ex)
            {
                return View(ex.Message);
            }

        }

        [HttpPost("/Item/NewItemRoom")]

        public JsonResult AddingItems(int itemId, int roomsTo, int roomsFrom, int amountPerRoom)
        {
            try
            {

                var room = _roomRepository.GetRoomById(roomsFrom);

                var appUserId = _userManager.GetUserId(HttpContext.User);

                if (room.Name != "Prostorija nije određena")
                {
                    var itemsVModel = new ItemsViewModel()
                    {
                        NonSerializedItemRoomDeduction = _nonSerializedItemRoomRepository.RoomAmountReduction(roomsFrom, amountPerRoom, appUserId, itemId),
                        
                        
                    };
                    if (itemsVModel.NonSerializedItemRoomDeduction.AmountPerRoom > 0)
                    {
                        itemsVModel.NonSerializedItemRoom = _nonSerializedItemRoomRepository.AddNewNonSerializedItemRoom(itemId, roomsTo, roomsFrom, amountPerRoom, appUserId);
                    }

                    return Json(itemsVModel);
                }
                else
                {
                    var itemsViewModel1 = new ItemsViewModel
                    {
                        NonSerializedItemRoom = _nonSerializedItemRoomRepository.AddNewNonSerializedItemRoom(itemId, roomsTo, roomsFrom, amountPerRoom, appUserId),
                        Room = _roomRepository.GetRoomById(roomsFrom),
                         

                    };
                    return Json(itemsViewModel1);
                }

                

 




 

             







            }
            catch(Exception ex)
            {
                return Json(ex.InnerException.Message);
            }


        }

        public IActionResult AllSerializedItems()
        {
            try
            {
                var itemsViewModel = new ItemsViewModel
                {
                    AllSerilizedItems = _serializedItemRepository.AllSerializedItems,
                };

                if (itemsViewModel != null)
                {
                    return View(itemsViewModel);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }

        }

        [HttpPost]
        public IActionResult UpdateSerialNumber(int serializedItemId, string serialNumber)
        {
            var itemsViewModel = new ItemsViewModel
            {
                SerializedItem = _serializedItemRepository.UpdateSerialNumber(serializedItemId, serialNumber)
            };


            return RedirectToAction("AllSerializedItems", itemsViewModel);


        }

        [HttpPost]
        public IActionResult UpdateSerialNumberFromDetailsPage(int serializedItemId)
        {
            var itemsViewModel = new ItemsViewModel
            {
                SerializedItem = _serializedItemRepository.UpdateSerialNumber(serializedItemId, HttpContext.Request.Form["serialNumber"])
            };

            return RedirectToAction("SerializedItemsDetails", new { id = serializedItemId });


        }

        public IActionResult SerializedItemsDetails(int id)
        {
            try
            {
                var itemsViewModel = new ItemsViewModel()
                {
                    SerializedItem = _serializedItemRepository.GetSerializedItemById(id),
                    CurrentUser = _itemUserRepository.GetItemUserBySerializedItemId(id),
                    CurrentRoom = _itemUserRepository.GetRoomBySerializedItemId(id),
                    AllItemsRooms = _itemRoomRepository.AllItemsRooms.Where(x => x.SerializedItemId == id).ToList()
                };

      

               
                //Uzimanje suppliera
               itemsViewModel.SerializedItem.InvoiceItem = _invoiceItemRepository.GetInvoiceItemById(itemsViewModel.SerializedItem.InvoiceItemId);

               itemsViewModel.SerializedItem.InvoiceItem.Invoice = _invoiceRepository.GetInvoiceById(itemsViewModel.SerializedItem.InvoiceItem.InvoiceId);

               itemsViewModel.SerializedItem.InvoiceItem.Invoice.Supplier = _supplierRepository.GetSupplierById(itemsViewModel.SerializedItem.InvoiceItem.Invoice.SupplierId);

                

                var roomsToSerializedItems = _roomRepository.AllRooms.Where(x => x.Id != itemsViewModel.CurrentRoom.Id && x.Name != "Prostorija nije određena").Select(i => new
                {
                    Text = i.Name + "-" + i.Branch.Name,
                    Value = i.Id
                }).ToList();



                ViewBag.roomsToSerializedItems = new SelectList(roomsToSerializedItems, "Value", "Text");

                var allItemUsers = _itemUserRepository.AllItemsUsers.Where(x => x.Id != itemsViewModel.CurrentUser.Id && x.Name != "Korisnik nije određen").Select(i => new
                {
                    Text = i.Name + " " + " "+ i.LastName,
                    Value = i.Id
                }).ToList();

                ViewBag.allItemUsers = new SelectList(allItemUsers, "Value", "Text");


                return View(itemsViewModel);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }

        }

        [HttpPost("/Item/NewSerializedItemRoom")]

        public JsonResult AddingSerializedItemsRooms(int serializedItemId, int currentRoom, int roomsTo, int itemUser)
        {
            try
            {
                var appUserId = _userManager.GetUserId(HttpContext.User);


                if(roomsTo == 99)
                {
                    var itemViewModelNoRoomChange = new ItemsViewModel
                    {
                        NewItemRoom = _itemRoomRepository.AddNewSerializedItemRoom(serializedItemId, currentRoom, currentRoom, itemUser, appUserId),
                        SerializedItem = _serializedItemRepository.GetSerializedItemById(serializedItemId)
                    };

                    itemViewModelNoRoomChange.SerializedItem = _serializedItemRepository.UpdateCurrentUserOfSerializedItem(serializedItemId, itemUser);

                    return Json(itemViewModelNoRoomChange);
                }
                else if(itemUser == 109)
                {
                    var itemViewModelNoUserChange = new ItemsViewModel
                    {
                        CurrentUser = _itemUserRepository.GetItemUserBySerializedItemId(serializedItemId),
                        SerializedItem = _serializedItemRepository.GetSerializedItemById(serializedItemId)
                    };

                    itemViewModelNoUserChange.NewItemRoom = _itemRoomRepository.AddNewSerializedItemRoom(serializedItemId, currentRoom, roomsTo, itemViewModelNoUserChange.CurrentUser.Id, appUserId);
                    itemViewModelNoUserChange.SerializedItem = _serializedItemRepository.UpdateCurrentRoomOfSerializedItem(serializedItemId, roomsTo);
                    return Json(itemViewModelNoUserChange);
                }
                else
                {
                    var itemViewModel = new ItemsViewModel
                    {
                        NewItemRoom = _itemRoomRepository.AddNewSerializedItemRoom(serializedItemId, currentRoom, roomsTo, itemUser, appUserId),
                        SerializedItem = _serializedItemRepository.GetSerializedItemById(serializedItemId)
                    };

                    itemViewModel.SerializedItem = _serializedItemRepository.UpdateCurrentRoomOfSerializedItem(serializedItemId, roomsTo);
                    itemViewModel.SerializedItem = _serializedItemRepository.UpdateCurrentUserOfSerializedItem(serializedItemId, itemUser);


                    return Json(itemViewModel);
                }


            }
            catch (Exception ex)
            {
                return Json(ex.InnerException.Message);
            }


        }

        public IActionResult InvoiceSummary(int id)
        {



            return View();
        }
    }
}
