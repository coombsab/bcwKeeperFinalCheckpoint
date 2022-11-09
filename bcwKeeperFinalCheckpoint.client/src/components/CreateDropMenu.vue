<template>
  <div class="dropdown sm-hidden z-1">
    <button class="btn dropdown-toggle" type="button" id="createDropDown" data-bs-toggle="dropdown"
      aria-haspopup="true" aria-expanded="false">
      Create
    </button>
    <div class="dropdown-menu" aria-labelledby="createDropDown">
      <div class="d-flex flex-column">
        <button class="btn"  data-bs-toggle="modal" data-bs-target="#createKeepModal">New Keep</button>
        <button class="btn"  data-bs-toggle="modal" data-bs-target="#createVaultModal">New Vault</button>
      </div>
    </div>
  </div>
  <div class="dropup md-hidden">
    <button class="btn btn-secondary dropdown-toggle" type="button" id="createDropUp" data-bs-toggle="dropdown"
      aria-haspopup="true" aria-expanded="false">
      Create
    </button>
    <div class="dropdown-menu" aria-labelledby="createDropUp">
      <div class="d-flex flex-column">
        <button class="btn"  data-bs-toggle="modal" data-bs-target="#createKeepModal">New Keep</button>
        <button class="btn"  data-bs-toggle="modal" data-bs-target="#createVaultModal">New Vault</button>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  setup() {

    return {

    }
  }
}
</script>

<style scoped lang="scss">

</style>