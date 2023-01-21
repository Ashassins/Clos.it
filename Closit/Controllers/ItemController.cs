using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc; // the one that holds controller

namespace Closit.Controllers {
    public class ItemController : Controller {
        [HttpPost, ActionName("Create")]
        public void CreateItem() {

        }

        [HttpPost, ActionName("Read")]
        public void ReadItem() {

        }
        [HttpPost, ActionName("Update")]
        public void UpdateItem() {

        }

        [HttpPost, ActionName("Delete")]
        public void DeleteItem() {

        }
    }
}