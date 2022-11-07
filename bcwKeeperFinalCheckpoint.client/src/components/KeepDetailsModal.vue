<template>
  <div class="modal-bg" id="keepDetailsModal">
    <div class="modal-content-wrapper">
      <div class="modal-content">
        <div class="container-fluid p-0">
          <div class="row">
            <div class="col-12 col-md-6">
              <div class="keep-img" :style="{ backgroundImage: `url(${keep?.img})` }"></div>
            </div>
            <div class="col-12 col-md-6 d-flex flex-column align-items-center justify-content-evenly px-5">
              <div class="d-flex gap-3">
                <div class="d-flex gap-2">
                  <img src="../assets/img/views.png" alt="">
                  <span>{{ keep?.views }}</span>
                </div>
                <div class="d-flex gap-2">
                  <img src="../assets/img/keeps.png" alt="">
                  <span>{{ keep?.kept }}</span>
                </div>
              </div>
              <div class="">
                <span>{{ keep?.description }}</span>
              </div>
              <div class="d-flex flex-wrap justify-content-between align-items-center w-100" id="keepDetailsModalContent">
                <div class="d-flex gap-2 align-items-center">
                  <span>DROPDOWN</span>
                  <button class="btn">save</button>
                </div>
                <div class="d-flex gap-2 align-items-center">
                  <span>USER IMG</span>
                  <span>USER NAME</span>
                </div>
              </div>
            </div>
          </div>
        </div>

      </div>
    </div>
  </div>
</template>

<script>
import { computed } from "@vue/reactivity";
import { onMounted } from "vue";
import { AppState } from "../AppState";

export default {
  setup() {
    function setup() {
      let modalBg = document.getElementById("keepDetailsModal")
      let modal = document.getElementById("keepDetailsModalContent")
      modalBg.addEventListener("click", closeModal)
      modal.addEventListener("click", modalClick)
    }
    function modalClick(event) {
      event.preventDefault();
      event.stopPropagation();
      event.stopImmediatePropagation();
      return false;
    }

    function closeModal() {
      let modal = document.getElementById("keepDetailsModal")
      let body = document.querySelector("body")
      modal.style.display = "none"
      body.style.overflow = "auto"
    }

    onMounted(() => {
      setup()
    })
    return {
      keep: computed(() => AppState.activeKeep),
    }
  }
}
</script>

<style scoped lang="scss">
.modal-bg {
  display: none;
  position: fixed;
  top: 0;
  left: 0;
  height: 100vh;
  width: 100vw;
  background-color: rgba(0, 0, 0, 0.5);
  z-index: 2000;
}

.modal-content-wrapper {
  height: 100%;
  width: 100%;
  position: relative;
  display: flex;
  justify-content: center;
  align-items: center;
  z-index: 2001;
}

.modal-content {
  height: 100vh;
  width: 100vw;
  background-color: #E5E5E5;
  border-radius: 6.94872px;
  z-index: 2002;
}

.container-fluid {
  height: 100%;
}

.row {
  height: 100%;
}

.keep-img {
  height: 100%;
  width: 100%;
  background-position: center;
  background-size: cover;
  border-radius: 6.94872px 0 0 6.94872px;
}

@media screen and (min-width: 768px) {
  .modal-content {
    height: 70vh;
    width: 70vw;
  }
}
</style>