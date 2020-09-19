using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Text;

public class PersonaBLL{  

    public static bool Guardar(Persona persona)
        {
            if (!Existe(persona.PersonaId)) { return Insertar(persona); }
            else { return Modificar(persona); }
        }

        public static bool Eliminar(int Id)
        {
            Contexto datos = new Contexto();
            bool esOk = false;

            try
            {
                var persona = datos.Persona.Find(Id); 
                if(persona!= null)
                {
                    datos.Persona.Remove(persona);
                    esOk = datos.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                datos.Dispose();
            }
            return esOk;

        }

        private static bool Insertar(Persona persona)
        {
            Contexto datos = new Contexto();
            bool esOk = false;

            try
            {
                if(datos.Persona.Add(persona) != null) { esOk = datos.SaveChanges() > 0; }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                datos.Dispose();
            }
            return esOk;
        }

        public static bool Existe(int Id)
        {
            Contexto datos = new Contexto();
            bool esOk = false;

            try
            {
                esOk = datos.Persona.Any(e => e.PersonaId == Id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                datos.Dispose();
            }
            return esOk;
        }

        private static bool Modificar(Persona persona)
        {
            Contexto datos = new Contexto();
            bool esOk = false;

            try
            {
                datos.Entry(persona).State = EntityState.Modified;
                esOk = datos.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                datos.Dispose();
            }
            return esOk;
        }

        public static Persona Buscar(int Id)
        {
            Contexto datos = new Contexto();
            Persona persona= new Persona();

            try
            {
                persona= datos.Persona.Find(Id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                datos.Dispose();
            }
            return persona;
        }
} 