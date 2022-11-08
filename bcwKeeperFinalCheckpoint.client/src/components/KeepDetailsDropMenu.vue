<template>
  <div class="d-flex gap-2 align-items-center" v-if="myVaults.length > 0">
    <select name="selectVault" id="selectVault" v-model="editable.vaultId" placeholder="Select a Vault" required>
      <option v-for="v in myVaults" :value="v.id">{{ v.name }}</option>
    </select>
    <button class="btn" type="submit" @click="saveKeepToVault()">save</button>
  </div>
  <div v-else><span>You have no vaults.</span></div>
</template>

<script>
import { computed } from "@vue/reactivity";
import { ref } from "vue";
import { AppState } from "../AppState";
import { Keep } from "../models/Keep";
import Pop from "../utils/Pop";

export default {
  props: {
    keep: { type: Keep, required: true }
  },
  setup(props) {
    const editable = ref({})

    return {
      editable,
      myVaults: computed(() => AppState.myVaults),
      async saveKeepToVault() {
        try {
          console.log("saving keep to vault", this.editable.vaultId)
          Pop.toast(`Saved ${props.keep.name} to vault.`)
        }
        catch (error) {
          Pop.error(error.message, "[saveKeepToVault]")
        }
      }
    }
  }
}
</script>

<style scoped lang="scss">

</style>