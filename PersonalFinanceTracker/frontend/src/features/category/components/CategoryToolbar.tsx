import {
 Button,
 Form,
 InputGroup
} from "react-bootstrap";

type Props = {
 search: string;

 onSearchChange:
 (value: string) => void;

 onCreate: () => void;
};

export function CategoryToolbar({
 search,
 onSearchChange,
 onCreate
}: Props) {

 return (

<div
className="
d-flex
gap-2
mb-3">

<InputGroup>

<Form.Control
placeholder="Search"
value={search}
onChange={(e)=>
onSearchChange(
e.target.value
)}
/>

</InputGroup>
<Button onClick={onCreate} >
Add Category
</Button>
</div>
);
}