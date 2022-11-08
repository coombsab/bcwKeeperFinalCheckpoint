<template>
<!-- Modal -->
<div class="modal fade" id="formModal" tabindex="-1" aria-labelledby="formModalLabel" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <h1 class="modal-title fs-5" id="formModalLabel">{{title}}</h1>
        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
      </div>
      <div class="modal-body">
        <slot>

        </slot>
      </div>
    </div>
  </div>
</div>
</template>

<script>
export default {
  props: {
    title: { type: String, required: true }
  },
  setup() {

    return {

    }
  }
}
</script>

<style scoped lang="scss">

</style>