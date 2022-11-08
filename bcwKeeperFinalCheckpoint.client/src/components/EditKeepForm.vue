<template>
  <form @submit.prevent="createKeep()">
    <div class="form-floating mb-3">
      <input type="text" class="form-control" name="keepName" id="keepName" placeholder="Name" required v-model="editable.name">
      <label for="keepName">Name</label>
    </div>
    <div class="form-floating mb-3">
      <input type="url" class="form-control" name="keepImg" id="keepImg" placeholder="Image URL" required v-model="editable.img">
      <label for="keepImg">Image URL</label>
    </div>
    <div class="form-floating">
      <input type="url" class="form-control" name="keepTags" id="keepTags" placeholder="Add Tags" required v-model="editable.tags">
      <label for="keepTags">Add Tags</label>
    </div>
    <div class="mb-3 ps-2">
      <span>* Separate tags with a comma (e.g. Plants,Animals)</span>
    </div>
    <div class="form-floating mb-3">
      <textarea class="form-control" name="keepDescription" id="keepDescription"
        placeholder="Keep Description" required v-model="editable.description"></textarea>
      <label for="keepDescription">Keep Description</label>
    </div>
    <div class="text-end">
      <button class="btn btn-dark" type="submit">Create</button>
    </div>
  </form>
</template>

<script>
import { ref, watchEffect } from "vue";
import { AppState } from "../AppState";

export default {
  setup() {
    const editable = ref({})

    watchEffect(() => {
      editable.value = {...AppState.activeKeep}
    })

    return {
      editable,
      async createKeep() {
        try {
          console.log("Creating a keep, whee")
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

</style>