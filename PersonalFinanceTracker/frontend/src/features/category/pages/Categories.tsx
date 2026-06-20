import { useState } from "react";
import { Container } from "react-bootstrap";

import { CategoryToolbar } from "../components/CategoryToolbar";
import { CategoryGrid } from "../components/CategoryGrid";
import { CategoryModal } from "../components/CategoryModal";

export default function Categories() {

  const [search, setSearch] =
    useState("");

  const [show, setShow] =
    useState(false);

  const [selected, setSelected] =
    useState<any>(null);

  const openCreate = () => {
    setSelected(null);
    setShow(true);
  };

  const openEdit = (
    item: any
  ) => {
    setSelected(item);
    setShow(true);
  };

  return (
    <Container className="mt-3">

      <CategoryToolbar
        search={search}
        onSearchChange={setSearch}
        onCreate={openCreate}
      />

      <CategoryGrid
        search={search}
        onEdit={openEdit}
      />

      <CategoryModal
        show={show}
        category={selected}
        onClose={() =>
          setShow(false)
        }
      />

    </Container>
  );
}