using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;
using System.Management;
using System.Net.NetworkInformation;
using System.Windows.Forms;

namespace AccesoHWySO
{
    public class clsSystemAcesso
    {
        public string ObtenerNumeroSerial()
        {
            try
            {
                ManagementObjectSearcher loSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");
                foreach (ManagementObject loDisk in loSearcher.Get())
                {
                    return loDisk["SerialNumber"]?.ToString();
                }
            }
            catch (Exception ex)
            {
                return $"Erro al obtener el numero de serie: {ex.Message}";
            }
            return "No se encontro el numero de serie";
        }
        public  int ObtenerCantidadUnidadesDisco()
        {
            try
            {
                DriveInfo[] loAllDrives = DriveInfo.GetDrives();
                return loAllDrives.Length;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }

        public  string ObtenerInventarioGeneralSistema()
        {
            try
            {
                string lsInventario = "";

                //Procesadores
                lsInventario += "Procesadores:\n";
                ManagementObjectSearcher loSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_Processor");
                foreach ( ManagementObject loProcesadores in loSearcher.Get())
                {
                    lsInventario += $"  - {loProcesadores["Name"]} - {loProcesadores["NumberOfCores"]} Cores\n";
                }
                // RAM
                lsInventario += "\nMemoria RAM (MB):\n";
                loSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMemory");
                foreach (ManagementObject loRam in loSearcher.Get())
                {
                    long lnRamSize = Convert.ToInt64(loRam["Capacity"]) / (1024 * 1024);
                    lsInventario += $"  - {lnRamSize} MB\n";
                }

                // NIC (Adaptadores de Red)
                lsInventario += "\nAdaptadores de Red:\n";
                NetworkInterface[] loNICs = NetworkInterface.GetAllNetworkInterfaces();
                foreach (NetworkInterface loNic in loNICs)
                {
                    lsInventario += $"  - {loNic.Name} - {loNic.Description}\n";
                }

                // Parches
                lsInventario += "\nParches Instalados:\n";
                loSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_QuickFixEngineering");
                foreach (ManagementObject loParche in loSearcher.Get())
                {
                    lsInventario += $"  - {loParche["HotFixID"]} - {loParche["Description"]}\n";
                }

                return lsInventario;
            }
            catch (Exception loEx)
            {
                return $"Error al obtener el inventario: {loEx.Message}";
            }
        }

        public  string ObtenerMACAddress()
        {
            try
            {
                foreach(NetworkInterface loNIC in NetworkInterface.GetAllNetworkInterfaces())
                {
                    if(loNIC.OperationalStatus == OperationalStatus.Up)
                    {
                        return loNIC.GetPhysicalAddress().ToString();
                    }
                }
            }
            catch (Exception loEx)
            {
                return $"Error al obtener la MAC Address: {loEx.Message}";
            }
            return "No se encontró una dirección MAC operativa";
        }

        public  void CrearClaveRegistro(string pKeyPath,string pKeyName,string pKeyValue)
        {
            try
            {
                RegistryKey oKey = Registry.CurrentUser.CreateSubKey(pKeyPath);
                oKey.SetValue(pKeyName,pKeyValue);
                oKey.Close();
                MessageBox.Show("Clave creada o modificada con exito.");
            }catch (Exception loEx)
            {
                MessageBox.Show($"Error al crear la clave del registro: {loEx.Message}");
            }
        }

        public string LeerClaveRegistro(string pKeyPath,string pKeyName)
        {
            try
            {
                RegistryKey oKey = Registry.CurrentUser.OpenSubKey(pKeyPath);
                if(oKey != null)
                {
                    return oKey.GetValue(pKeyName)?.ToString();
                }
                return "Clave no encontrada";
            }
            catch(Exception loEx)
            {
                return $"Error al leer la clave del registro: {loEx.Message}";
            }
        }
        public void BorrarClaveRegisto(string pKeyPath, string pKeyName)
        {
            try
            {
                RegistryKey oKey = Registry.CurrentUser.OpenSubKey(pKeyPath, true);
                if(oKey != null)
                {
                    oKey.DeleteValue(pKeyName);
                    oKey.Close();
                }
            }
            catch (Exception loEx)
            {
                MessageBox.Show($"Error al borrar la clave del registro: {loEx.Message}");
            }
        }
        public void ModificarClaveResgitro(string pKeyPath, string pKeyName, string pNewValue)
        {
            CrearClaveRegistro(pKeyPath, pKeyName,pNewValue);
        }

        public string ObtenerProcesosActivos()
        {
            try
            {
                Process[] loListaProcesos = Process.GetProcesses();
                string lsProcesos = "";
                foreach (Process loProceso in loListaProcesos)
                {
                    lsProcesos += $"  - {loProceso.ProcessName} (ID: {loProceso.Id})\n";
                }
                return lsProcesos;
            }catch(Exception loEx)
            {
                return $"Error al obtener los procesos: {loEx.Message}";
            }
        }
        public void KillProcesos(int pProcesoId)
        {
            try
            {
                Process loProceso = Process.GetProcessById(pProcesoId);
                loProceso.Kill();
                MessageBox.Show($"Proceso {pProcesoId} finalizado correctamente");
            }
            catch(Exception loEx)
            {
                MessageBox.Show($"Error al finalizar el proceso {pProcesoId}: {loEx.Message}");
            }
        }
    }
}
