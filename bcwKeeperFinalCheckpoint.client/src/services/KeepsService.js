import { AppState } from "../AppState";
import { Keep } from "../models/Keep";
import { KeepInVault } from "../models/KeepInVault";
import { api } from "./AxiosService";

class KeepsService {
  async getKeeps()  {
    AppState.keeps = []
    const res = await api.get("api/keeps")
    AppState.keeps = res.data.map(data => new Keep(data))
  }

  async setActiveKeep(keep) {
    AppState.activeKeep = null
    const res = await api.get(`api/keeps/${keep.id}`)
    if(keep.vaultKeepId) {
      res.data.vaultKeepId = keep.vaultKeepId
      AppState.activeKeep = new KeepInVault(res.data)
    } else {
      AppState.activeKeep = new Keep(res.data)
    }

  }

  async getMyKeepsById(profileId) {
    AppState.myKeeps = []
    const res = await api.get(`api/profiles/${profileId}/keeps`)
    AppState.myKeeps = res.data.map(data => new Keep(data))
  }

  async getKeepsByProfileId(profileId) {
    AppState.keeps = []
    const res = await api.get(`api/profiles/${profileId}/keeps`)
    AppState.keeps = res.data.map(data => new Keep(data))
  }

  async getKeepsInVault(vaultId) {
    AppState.keepsInVault = []
    const res = await api.get(`api/vaults/${vaultId}/keeps`)
    AppState.keepsInVault = res.data.map(data => new KeepInVault(data))
  }

  async deleteKeep(keepId) {
    const res = await api.delete(`api/keeps/${keepId}`)
    AppState.keeps = AppState.keeps.filter(keep => keep.id !== keepId)
    AppState.myKeeps = AppState.myKeeps.filter(keep => keep.id !== keepId)
    AppState.keepsInVault = AppState.keepsInVault.filter(keep => keep.id !== keepId)
  }

  async createKeep(keepData) {
    const res = await api.post("api/keeps", keepData)
    AppState.keeps.push(new Keep(res.data))
    AppState.myKeeps.push(new Keep(res.data))
  }
}

export const keepsService = new KeepsService();