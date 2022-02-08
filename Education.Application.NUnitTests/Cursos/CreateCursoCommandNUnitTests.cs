using AutoFixture;
using AutoMapper;
using Education.Application.Helper;
using Education.Domain;
using Education.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading;
namespace Education.Application.Cursos
{
    [TestFixture]
    public class CreateCursoQueryNUnitTests
    {
#pragma warning disable CS8618
        private CreateCursoCommand.CreateCursoCommandHandler handlerCursoCreate;
#pragma warning restore CS8618


        [SetUp]
        public void Setup()
        {
            var fixture = new Fixture();
            var cursoRecords = fixture.CreateMany<Curso>().ToList();

            cursoRecords.Add(fixture.Build<Curso>()
                .With(tr => tr.CursoId, Guid.Empty)
                .Create()
            );


            var options = new DbContextOptionsBuilder<EducationDbContext>()
               .UseInMemoryDatabase(databaseName: $"EducationDbContext-{Guid.NewGuid()}")
               .Options;

            var educationDbContextFake = new EducationDbContext(options);
            educationDbContextFake.Cursos.AddRange(cursoRecords);
            educationDbContextFake.SaveChanges();

            var mapConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingTest());
            }
            );
            var mapper = mapConfig.CreateMapper();

            handlerCursoCreate = new CreateCursoCommand.CreateCursoCommandHandler(educationDbContextFake);

        }


        [Test]
        public async void CreateCursoCommand_InputCurso_ReturnsNumber()
        {
            CreateCursoCommand.CreateCursoCommandRequest request = new();
            request.FechaPublicacion = DateTime.UtcNow.AddDays(59);
            request.Titulo = "Libro de Pruebas Automaticas en NET";
            request.Descripcion = "Aprende a crear unit test desde cero";
            request.Precio = 99;


            var resultados = await handlerCursoCreate.Handle(request, null);

            Assert.That(resultados, Is.EqualTo(Unit.Value));
        }
    }
}
