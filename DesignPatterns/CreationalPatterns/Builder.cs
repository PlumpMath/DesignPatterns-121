using System.Text;

namespace AllIn.CreationalPatterns
{
    /* Когда процесс создания нового объекта не должен зависеть от того, из каких частей этот объект состоит
     *    и как эти части связаны между собой

     Когда необходимо обеспечить получение различных вариаций объекта в процессе его создания*/

    class Builder
    {
        public class Flour
        {
            public string Sort { get; set; }
        }

        public class Salt { }

        public class Addictives
        {
            public string Name { get; set; }
        }

        public class Bread
        {
            public Flour WheatFlour { get; set; }

            public Flour RyeFlour { get; set; }

            public Salt Salt { get; set; }

            public Addictives Addictives { get; set; }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();

                if (WheatFlour != null)
                    sb.Append($"Пшеничная мука {WheatFlour}");

                if (RyeFlour != null)
                    sb.Append($"Ржаная мука {RyeFlour}");

                if (Salt != null)
                    sb.Append($"Соль {Salt}");

                if (Addictives != null)
                    sb.Append($"Пищевы добавки {Addictives}");

                return sb.ToString();
            }
        }

        //Builder
        public abstract class BreadBuilder
        {
            public Bread Bread { get; private set; }

            protected BreadBuilder()
            {
                Bread = new Bread();
            }

            public abstract void SetWheatFlour();

            public abstract void SetRyeFlour();

            public abstract void SetSalt();

            public abstract void SetAddictives();
        }

        //Director
        public class Baker
        {
            public void Bake(BreadBuilder breadBuilder)
            {
                breadBuilder.SetRyeFlour();
                breadBuilder.SetWheatFlour();
                breadBuilder.SetSalt();
                breadBuilder.SetAddictives();
            }
        }

        //ConcreteBuilder1
        public class RyeBreadBuilder : BreadBuilder
        {
            public override void SetAddictives()
            {
            }

            public override void SetRyeFlour()
            {
                Bread.RyeFlour = new Flour() { Sort = "1" };
            }

            public override void SetSalt()
            {
                Bread.Salt = new Salt();
            }

            public override void SetWheatFlour()
            {
            }
        }

        //ConcreteBuilder2
        public class WheatBreadBuilder : BreadBuilder
        {
            public override void SetAddictives()
            {
                Bread.Addictives = new Addictives() { Name = "Super-duper addict" };
            }

            public override void SetRyeFlour()
            {
            }

            public override void SetSalt()
            {
                Bread.Salt = new Salt();
            }

            public override void SetWheatFlour()
            {
                Bread.WheatFlour = new Flour() { Sort = "1-st sort flour" };
            }
        }

        //static void Main(string[] args)
        //{
        //    //Creating baker object
        //    Baker baker = new Baker();

        //    //Creating RyeBreadBuilder
        //    BreadBuilder breadBuilder = new RyeBreadBuilder();

        //    //Making bread
        //    baker.Bake(breadBuilder);
        //    Bread ryeBread = breadBuilder.Bread;
        //    Console.WriteLine(ryeBread);


        //    breadBuilder = new WheatBreadBuilder();

        //    baker.Bake(breadBuilder);

        //    Bread wheatBread = breadBuilder.Bread;

        //    Console.WriteLine(wheatBread);
        
    }
}
