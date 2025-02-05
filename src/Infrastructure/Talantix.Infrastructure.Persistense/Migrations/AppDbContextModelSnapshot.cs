﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Talantix.Infrastructure.EntityFramework;

#nullable disable

namespace Talantix.Infrastructure.Persistense.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true);

            modelBuilder.Entity("Talantix.Core.Domain.Todos.Todo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT")
                        .HasColumnName("created_at");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("description");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("title");

                    b.HasKey("Id")
                        .HasName("pk_todos");

                    b.ToTable("todos", (string)null);
                });

            modelBuilder.Entity("Talantix.Core.Domain.Todos.Todo", b =>
                {
                    b.OwnsOne("Talantix.Core.Domain.Todos.TodoStatus", "Status", b1 =>
                        {
                            b1.Property<int>("TodoId")
                                .HasColumnType("INTEGER")
                                .HasColumnName("id");

                            b1.Property<string>("Status")
                                .IsRequired()
                                .HasColumnType("TEXT")
                                .HasColumnName("status");

                            b1.HasKey("TodoId");

                            b1.ToTable("todos");

                            b1.WithOwner()
                                .HasForeignKey("TodoId")
                                .HasConstraintName("fk_todos_todos_id");
                        });

                    b.Navigation("Status")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
