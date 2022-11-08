<template>
  <form @submit.prevent="editVault()">
    <div class="form-floating mb-3">
      <input type="text" class="form-control" name="vaultName" id="editVaultName" placeholder="Name" required v-model="editable.name">
      <label for="editVaultName">Name</label>
    </div>
    <div class="form-floating mb-3">
      <input type="url" class="form-control" name="vaultImg" id="editVaultImg" placeholder="Image URL" required v-model="editable.img">
      <label for="editVaultImg">Image URL</label>
    </div>
    <div class="text-end">
      <span>Private vaults can only be seen by you</span>
      <div class="d-flex gap-2 align-items-center justify-content-end">
        <input type="checkbox" v-model="editable.isPrivate">
        <span>Make Vault Private?</span>
      </div>
      <button class="btn btn-dark px-5 py-1" type="submit">Create Vault</button>
    </div>
  </form>
</template>

<script>
import { Modal } from "bootstrap";
import { ref, watchEffect } from "vue";
import { useRoute } from "vue-router";
import { AppState } from "../AppState";
import { vaultsService } from "../services/VaultsService";
import Pop from "../utils/Pop";

export default {
  setup() {
    const editable = ref({})
    const route = useRoute()

    watchEffect(() => {
      editable.value = {...AppState.activeVault}
    })
    
    return {
      editable,
      route,
      async editVault() {
        try {
          await vaultsService.editVault(editable.value, route.params.vaultId)
          Modal.getOrCreateInstance("#editVaultModal").hide()
        }
        catch(error) {
          Pop.error(error.message, "[createKeep]")
        }
      }
    }
  }
}
</script>

<style scoped lang="scss">
#keepDescription{ 
  height: 10.8rem;
}
</style>