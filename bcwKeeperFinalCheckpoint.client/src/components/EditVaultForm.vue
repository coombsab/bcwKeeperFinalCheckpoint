<template>
  <form @submit.prevent="createVault()">
    <div class="form-floating mb-3">
      <input type="text" class="form-control" name="vaultName" id="vaultName" placeholder="Name" required v-model="editable.name">
      <label for="vaultName">Name</label>
    </div>
    <div class="form-floating mb-3">
      <input type="url" class="form-control" name="vaultImg" id="vaultImg" placeholder="Image URL" required v-model="editable.img">
      <label for="vaultImg">Image URL</label>
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
import { ref, watchEffect } from "vue";
import { AppState } from "../AppState";
import Pop from "../utils/Pop";

export default {
  setup() {
    const editable = ref({})

    watchEffect(() => {
      editable.value = {...AppState.activeVault}
    })
    
    return {
      editable,
      async createVault() {
        try {
          console.log("Creating a keep, whee")
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