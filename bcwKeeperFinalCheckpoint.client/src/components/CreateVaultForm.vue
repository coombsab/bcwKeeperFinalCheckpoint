<template>
  <form @submit.prevent="createVault()">
    <div class="form-floating mb-3">
      <input type="text" class="form-control" name="vaultName" id="vaultName" placeholder="Name" required v-model="editable.name" onfocus="select()">
      <label for="vaultName">Name</label>
    </div>
    <div class="form-floating mb-3">
      <input type="url" class="form-control" name="vaultImg" id="vaultImg" placeholder="Image URL" required v-model="editable.img" onfocus="select()">
      <label for="vaultImg">Image URL</label>
    </div>
    <div class="text-end">
      <span>Private vaults can only be seen by you</span>
      <div class="d-flex gap-2 align-items-center justify-content-end">
        <input type="checkbox" v-model="editable.isPrivate" default="false">
        <span>Make Vault Private?</span>
      </div>
      <button class="btn btn-dark px-5 py-1" type="submit">Create Vault</button>
    </div>
  </form>
</template>

<script>
import { Modal } from "bootstrap";
import { ref } from "vue";
import { vaultsService } from "../services/VaultsService";
import Pop from "../utils/Pop";

export default {
  setup() {
    const editable = ref({ isPrivate: false })
    return {
      editable,
      async createVault() {
        try {
          await vaultsService.createVault(editable.value)
          Modal.getOrCreateInstance("#createVaultModal").hide()
          Pop.toast(`Created ${editable.value.name}`, "success", "top")
          editable.value = { isPrivate: false }
        }
        catch(error) {
          Pop.error(error.message, "[createVault]")
        }
      }
    }
  }
}
</script>

<style scoped lang="scss">
</style>