using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonOop
{
    enum Gender { Male, Female };
    internal class FamilyMember
    {
        public FamilyMember Mother { get { return mother; } set { mother = value; } }
        public FamilyMember Father { get { return father; } set { father = value; } }
        public string Name { get { return name; } set { name = value; } }
        public Gender Sex { get { return sex; } set { sex = value; } }
        public List<FamilyMember> Children { get; }



        private FamilyMember mother;
        private FamilyMember father;
        private string name;
        private Gender sex;
        private List<FamilyMember> children;

        public void MothersLine()
        {
            if (sex == Gender.Female)
                Console.WriteLine(name);
            MothersLinePrivate();
        }
        private void MothersLinePrivate()
        {
            if (mother != null)
            {
                Console.WriteLine(mother.name);
                mother.MothersLinePrivate();
            }
        }

        public static void PrintRelative(FamilyMember fm)
        {
            string spouse = string.Empty;
            string kids = string.Empty;
            Console.WriteLine($"Я - {fm.name}");
            if (fm.children.Count > 0)
            {

                foreach (var f in fm.children)
                {
                    if (f.father != null && f.mother != null)
                    {
                        if (fm.Sex == Gender.Female)
                            spouse = "У меня есть муж - " + f.father.name;
                        else
                            spouse = "У меня есть супруга - " + f.mother.name;
                    }
                    kids = f.name + "," + kids;

                }
                Console.WriteLine(spouse);
                Console.WriteLine("Есть дети - " + kids);
            }
            else
            {
                Console.WriteLine("Детей нет!");
                Console.WriteLine($"У меня есть папа - {fm.father.name}");
                Console.WriteLine($"У меня есть мама - {fm.mother.name}");
                foreach (var f in fm.Father.children)
                {
                    if (f.father != null && f.mother != null)
                    {
                        if(!fm.Equals(f))
                        {
                        if (fm.Sex == Gender.Female)
                            Console.WriteLine("У меня есть брат - " + f.name);
                        else
                            Console.WriteLine("У меня есть сестра - " + f.name);

                        }
                    }
                }
            }
        }

        public void AddChild(FamilyMember child)
        {

            if (child != null)
                children.Add(child);
        }

        public FamilyMember()
        {
            children = new List<FamilyMember>();
        }

        public FamilyMember(FamilyMember Mother, FamilyMember Father, string Name, Gender Sex)
        {
            children = new List<FamilyMember>();
            this.mother = Mother;
            this.father = Father;
            this.name = Name;
            this.sex = Sex;
        }
    }

}
