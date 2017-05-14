using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeBoneGame.Model
{
    /// <summary>
    /// Repository of all the bones in the Human Body
    /// </summary>
    public class BoneRepository
    {
        private string[] _bones = new string[]{"Nasal" ,
"Lacrimal                                                                   " ,
"Inferior Nasal Concha                                                      " ,
"Maxiallary                                                                 " ,
"Zygomatic                                                                  " ,
"Temporal                                                                   " ,
"Palatine                                                                   " ,
"Parietal                                                                   " ,
"Malleus                                                                    " ,
"Incus                                                                      " ,
"Stapes                                                                     " ,
"Frontal                                                                    " ,
"Ethmoid                                                                    " ,
"Vomer                                                                      " ,
"Sphenoid                                                                   " ,
"Mandible                                                                   " ,
"Occipital                                                                  " ,
"Rib                                                                      " ,
"Hyoid                                                                      " ,
"Sternum                                                                    " ,
"Atlas" ,
"Axis" ,
"Cervical Vertebrae" ,
"Thoracic Vertebrae" ,
"Lumbar Vertebrae" ,
"Sacrum                                                                     " ,
"Coccyx                                                                     " ,
"Scapula                                                                    " ,
"Clavicle                                                                   " ,
"Humerus                                                                    " ,
"Radius                                                                     " ,
"Ulna                                                                       " ,
"Scaphoid                                                                   " ,
"Lunate                                                                     " ,
"Triquetrum                                                                 " ,
"Pisiform                                                                   " ,
"Hamate                                                                     " ,
"Capitate                                                                   " ,
"Trapezoid                                                                  " ,
"Trapezium                                                                  " ,
"Metacarpal" ,
"Proximal Phalange" ,
"Distal Phalange" ,
"Hip  " ,
"Ilium",
"Ischium",
"Pubis",
"Femur                                                                      " ,
"Patella                                                                    " ,
"Tibia                                                                      " ,
"Fibula                                                                     " ,
"Talus                                                                      " ,
"Calcaneus                                                                  " ,
"Navicular                                                                  " ,
"Medial Cuneiform                                                           " ,
"Middle Cuneiform                                                           " ,
"Lateral Cuneiform                                                          " ,
"Cuboid                                                                     " ,
"Metatarsal" ,
"Proximal Phalange" ,
"Distal Phalange" };
        private Random _randomGenerator;

        public List<string> GetBones()
        {
            var trimedBoneNames = new List<string>();
            foreach (var boneName in _bones)
                trimedBoneNames.Add(boneName.Trim());

            return trimedBoneNames;
        }


        public string GetRandomBone()
        {
            return _bones[_randomGenerator.Next(_bones.Length)];
        }

        public BoneRepository()
        {
            _randomGenerator = new Random();
        }
    }
}
