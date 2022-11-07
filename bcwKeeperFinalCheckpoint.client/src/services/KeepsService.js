import { AppState } from "../AppState";
import { Keep } from "../models/Keep";
import { api } from "./AxiosService";

class KeepsService {
  async getKeeps()  {
    AppState.keeps = []
    const res = await api.get("api/keeps")
    AppState.keeps = res.data.map(data => new Keep(data))
  }

  async setActiveKeep(keepId) {
    AppState.activeKeep = null
    const res = await api.get(`api/keeps/${keepId}`)
    let keep = new Keep(res.data)
    AppState.activeKeep = keep
    let keepIndex = AppState.keeps.findIndex(k => k.id === keep.id)
    AppState.keeps.splice(keepIndex, 1, keep)
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
}

export const keepsService = new KeepsService();