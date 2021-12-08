using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cantine.Controllers
{
    class TypesPaiementsController
    {
        private readonly NomControllerServices _service;
        private readonly IMapper _mapper;

        public NomControllerControler(NomControllerServices service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        //GET api/NomController
        [HttpGet]
        public ActionResult<IEnumerable<NomControllerDTO>> GetAllNomController()
        {
            IEnumerable<NomModel> listeNomController = _service.GetAllNomController();
            return Ok(_mapper.Map<IEnumerable<NomControllerDTO>>(listeNomController));
        }

        //GET api/NomController/{i}
        [HttpGet("{id}", Name = "GetNomModelById")]
        public ActionResult<NomControllerDTO> GetNomModelById(int id)
        {
            NomModel commandItem = _service.GetNomModelById(id);
            if (commandItem != null)
            {
                return Ok(_mapper.Map<NomControllerDTO>(commandItem));
            }
            return NotFound();
        }

        //POST api/NomController
        [HttpPost]
        public ActionResult<NomControllerDTO> CreateNomModel(NomModel obj)
        {
            _service.AddNomModel(obj);
            return CreatedAtRoute(nameof(GetNomModelById), new { Id = obj.Id }, obj);
        }

        //POST api/NomController/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateNomModel(int id, NomControllerDTO obj)
        {
            NomModel objFromRepo = _service.GetNomModelById(id);
            if (objFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(obj, objFromRepo);
            _service.UpdateNomModel(objFromRepo);
            return NoContent();
        }

        // Exemple d'appel
        // [{
        // "op":"replace",
        // "path":"",
        // "value":""
        // }]
        //PATCH api/NomController/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialNomModelUpdate(int id, JsonPatchDocument<NomModel> patchDoc)
        {
            NomModel objFromRepo = _service.GetNomModelById(id);
            if (objFromRepo == null)
            {
                return NotFound();
            }
            NomModel objToPatch = _mapper.Map<NomModel>(objFromRepo);
            patchDoc.ApplyTo(objToPatch, ModelState);
            if (!TryValidateModel(objToPatch))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(objToPatch, objFromRepo);
            _service.UpdateNomModel(objFromRepo);
            return NoContent();
        }

        //DELETE api/NomController/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteNomModel(int id)
        {
            NomModel obj = _service.GetNomModelById(id);
            if (obj == null)
            {
                return NotFound();
            }
            _service.DeleteNomModel(obj);
            return NoContent();
        }


    }
}
