import { AppState } from "../AppState"
import { api } from "./AxiosService"

class VaultKeepsService {
  async removeKeepFromVault(vaultKeepId) {
    await api.delete(`api/vaultkeeps/${vaultKeepId}`)
    AppState.keepsInVault = AppState.keepsInVault.filter(keep => keep.vaultKeepId !== vaultKeepId)
  }

  async saveKeepToVault(vaultId, keepId) {
    await api.post("api/vaultkeeps", { vaultId, keepId })
  }
}

export const vaultKeepsService = new VaultKeepsService()