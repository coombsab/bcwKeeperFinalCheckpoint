<template>
  <form @submit.prevent="createKeep()">
    <div class="form-floating mb-3">
      <input type="text" class="form-control" name="keepName" id="keepName" placeholder="Name" required v-model="editable.name" onfocus="select()">
      <label for="keepName">Name</label>
    </div>
    <div class="form-floating mb-3">
      <input type="url" class="form-control" name="keepImg" id="keepImg" placeholder="Image URL" required v-model="editable.img" onfocus="select()">
      <label for="keepImg">Image URL</label>
    </div>
    <div class="form-floating">
      <input type="text" class="form-control" name="keepTags" id="keepTags" placeholder="Add Tags" required v-model="editable.tags" onfocus="select()">
      <label for="keepTags">Add Tags</label>
    </div>
    <div class="mb-3 ps-2">
      <span>* Separate tags with a comma (e.g. Plants,Animals)</span>
    </div>
    <div class="form-floating mb-3">
      <textarea class="form-control" name="keepDescription" id="keepDescription"
        placeholder="Keep Description" required v-model="editable.description" onfocus="select()"></textarea>
      <label for="keepDescription">Keep Description</label>
    </div>
    <div class="text-end">
      <button class="btn btn-dark" type="submit">Create Keep</button>
    </div>
  </form>
</template>

<script>
import { Modal } from "bootstrap";
import { ref } from "vue";
import { keepsService } from "../services/KeepsService";
import Pop from "../utils/Pop";

export default {
  setup() {
    const editable = ref({})
    return {
      editable,
      async createKeep() {
        try {
          await keepsService.createKeep(editable.value)
          Modal.getOrCreateInstance("#createKeepModal").hide()
          Pop.toast(`Created ${editable.value.name}`, "success", "top")
          editable.value = {}
        }
        catch (error) {
          Pop.error(error.message, "[createKeep]")
        }
      }
    }
  }
}
</script>

<style scoped lang="scss">
textarea {
  height: 10.8rem !important;
}
</style>