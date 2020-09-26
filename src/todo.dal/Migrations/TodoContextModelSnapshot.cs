﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Todo.Dal;

namespace Todo.Dal.Migrations
{
    [DbContext(typeof(TodoContext))]
    partial class TodoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("dbo")
                .HasAnnotation("ProductVersion", "3.1.8");

            modelBuilder.Entity("Todo.Dal.Models.Tenant", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Tenants");

                    b.HasData(
                        new
                        {
                            Id = new Guid("68b45895-8b2c-4d83-8396-1959b59a21a6"),
                            Name = "Default Tenant"
                        });
                });

            modelBuilder.Entity("Todo.Dal.Models.TotoList", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("TenantId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("TenantId");

                    b.ToTable("TodoLists");

                    b.HasData(
                        new
                        {
                            Id = new Guid("81df3f6f-4bb8-4195-932e-a091c5019aad"),
                            Description = "First example todo list",
                            TenantId = new Guid("68b45895-8b2c-4d83-8396-1959b59a21a6"),
                            Title = "TodoList 1"
                        },
                        new
                        {
                            Id = new Guid("94260d4d-133f-403e-8b71-0521b87f2215"),
                            Description = "Second example todo list",
                            TenantId = new Guid("68b45895-8b2c-4d83-8396-1959b59a21a6"),
                            Title = "TodoList 2"
                        });
                });

            modelBuilder.Entity("Todo.Dal.TodoItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("DoWhat")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Done")
                        .HasColumnType("INTEGER");

                    b.Property<Guid?>("TenantId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("TodoListId")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("TotoListId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("TenantId");

                    b.HasIndex("TotoListId");

                    b.ToTable("TodoItems");

                    b.HasData(
                        new
                        {
                            Id = new Guid("a9fad21f-0305-410f-a8a1-b9c997cbfa7d"),
                            Description = "Hack all day",
                            DoWhat = "Hack",
                            Done = false,
                            TenantId = new Guid("68b45895-8b2c-4d83-8396-1959b59a21a6"),
                            TodoListId = new Guid("81df3f6f-4bb8-4195-932e-a091c5019aad")
                        },
                        new
                        {
                            Id = new Guid("b75cbfd1-2509-4362-beea-c59baa895bae"),
                            Description = "Hack all night",
                            DoWhat = "Hack even more",
                            Done = false,
                            TenantId = new Guid("68b45895-8b2c-4d83-8396-1959b59a21a6"),
                            TodoListId = new Guid("81df3f6f-4bb8-4195-932e-a091c5019aad")
                        },
                        new
                        {
                            Id = new Guid("1c16ccb0-a05b-4c0c-af38-4dfbc90076a3"),
                            Description = "Drink coffee all day",
                            DoWhat = "Drink coffee",
                            Done = false,
                            TenantId = new Guid("68b45895-8b2c-4d83-8396-1959b59a21a6"),
                            TodoListId = new Guid("94260d4d-133f-403e-8b71-0521b87f2215")
                        },
                        new
                        {
                            Id = new Guid("936a6bef-b102-427c-805a-e06b172dec8c"),
                            Description = "Drink coffee all night",
                            DoWhat = "Drink even more coffee",
                            Done = false,
                            TenantId = new Guid("68b45895-8b2c-4d83-8396-1959b59a21a6"),
                            TodoListId = new Guid("94260d4d-133f-403e-8b71-0521b87f2215")
                        });
                });

            modelBuilder.Entity("Todo.Dal.Models.TotoList", b =>
                {
                    b.HasOne("Todo.Dal.Models.Tenant", "Tenant")
                        .WithMany()
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("Todo.Dal.TodoItem", b =>
                {
                    b.HasOne("Todo.Dal.Models.Tenant", "Tenant")
                        .WithMany()
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Todo.Dal.Models.TotoList", "TotoList")
                        .WithMany("TodoItems")
                        .HasForeignKey("TotoListId");
                });
#pragma warning restore 612, 618
        }
    }
}