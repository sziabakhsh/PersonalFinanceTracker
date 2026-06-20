import {
 Modal
} from "react-bootstrap";

import {
 CategoryForm
} from "./CategoryForm";

export function CategoryModal({

show,
onClose,
category

}:any){

return(

<Modal
show={show}
onHide={onClose}
>

<Modal.Header closeButton>

<Modal.Title>

{
category
?
"Edit Category"
:
"Create Category"
}

</Modal.Title>

</Modal.Header>

<Modal.Body>

<CategoryForm
initialData={
category
}
onSuccess={
onClose
}
/>

</Modal.Body>

</Modal>

);

}