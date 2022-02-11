using AutoFixture;
using AutoMapper;
using Education.Application.Helper;
using Education.Domain;
using Education.Persistence;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Linq;


namespace Education.Application.Cursos
{
    [TestFixture]
    public class GetCursoQueryNUnitTests
    {

        private GetCursoQuery.GetCursoQueryHandler? handlerAllCursos;



        [SetUp]
        public void Setup()
        {
            // una libreria que sirve para generara datos de prueba
            var fixture = new Fixture();
            var cursoRecords = fixture.CreateMany<Curso>().ToList();

            cursoRecords.Add(fixture.Build<Curso>()
                .With(tr => tr.CursoId, Guid.Empty)
                .Create()
            );

            // utilizamos una base de datos en memoria
            var options = new DbContextOptionsBuilder<EducationDbContext>()
               // cada vez que se genere un test se generara una db diferente con un nuevo GUI
               .UseInMemoryDatabase(databaseName: $"EducationDbContext-{Guid.NewGuid()}")
               .Options;
            // creacion el db context
            var educationDbContextFake = new EducationDbContext(options);
            educationDbContextFake.Cursos.AddRange(cursoRecords);
            educationDbContextFake.SaveChanges();
            // aggregamos el map para las consultas
            var mapConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingTest());
            }
            );
            var mapper = mapConfig.CreateMapper();

            handlerAllCursos = new GetCursoQuery.GetCursoQueryHandler(educationDbContextFake, mapper);

        }


        [Test]
        public async void GetCursoQueryHandler_ConsultaCursos_ReturnsTrue()
        {
            // 1. Emular al Context que representa la instancia de EF - Listo


            // 2. Emular al Mapping Profile


            // 3. Instanciar un objeto de la clase GetCursoQuery.GetCursoQueryHandler y pasarle
            // como parametros los objetos context y mapping
            // GetCursoQueryHandler(context, mapping)  => handle

            GetCursoQuery.GetCursoQueryRequest request = new();
#pragma warning disable CS8602
            var resultados = await handlerAllCursos?.Handle(request, cancellationToken: new System.Threading.CancellationToken());
#pragma warning restore CS8602 

            Assert.IsNotNull(resultados);
        }
    }
}
