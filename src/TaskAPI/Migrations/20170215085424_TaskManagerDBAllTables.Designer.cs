using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using TaskAPI.Entities;

namespace TaskAPI.Migrations
{
    [DbContext(typeof(TaskManagementContext))]
    [Migration("20170215085424_TaskManagerDBAllTables")]
    partial class TaskManagerDBAllTables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TaskAPI.Entities.Assignment", b =>
                {
                    b.Property<int>("TaskId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("TaskId1");

                    b.Property<int>("UserId");

                    b.HasKey("TaskId");

                    b.HasIndex("TaskId1");

                    b.HasIndex("UserId");

                    b.ToTable("Assignments");
                });

            modelBuilder.Entity("TaskAPI.Entities.Task", b =>
                {
                    b.Property<int>("TaskId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BeginDateTime")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("DeadlineDateTime")
                        .HasMaxLength(50);

                    b.Property<string>("Requirements")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("TaskId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("TaskAPI.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TaskAPI.Entities.Assignment", b =>
                {
                    b.HasOne("TaskAPI.Entities.Task", "Task")
                        .WithMany()
                        .HasForeignKey("TaskId1");

                    b.HasOne("TaskAPI.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
